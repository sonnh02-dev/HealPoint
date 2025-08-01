
using AppointmentSchedulingApp.Domain.Commons;
using AppointmentSchedulingApp.Infrastructure.Data;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Infrastructure.Outbox;
using AppointmentSchedulingApp.SharedKernel;
using log4net.Config;
using log4net;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AppointmentSchedulingApp.Infrastructure.Search;
using AppointmentSchedulingApp.Application.Abstractions.Caching;
using AppointmentSchedulingApp.Infrastructure.Caching;
using AppointmentSchedulingApp.Application.Abstractions.Payment;
using AppointmentSchedulingApp.Infrastructure.Payments.Momo;
using AppointmentSchedulingApp.Infrastructure.Payments.VnPay;
using AppointmentSchedulingApp.Application.Abstractions.Notifications;
using AppointmentSchedulingApp.Infrastructure.Notifications;
using AppointmentSchedulingApp.Infrastructure.Persistence.Interceptors;
using AppointmentSchedulingApp.Application.Abstractions.EventBus;
using AppointmentSchedulingApp.Infrastructure.MessageBroker;
using Microsoft.Extensions.Options;
using Application.Users.GetByEmail;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System.Text;
using AppointmentSchedulingApp.Infrastructure.Authentication;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AppointmentSchedulingApp.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        //interceptor
        services.AddSingleton<PublishDomainEventsInterceptor>();
        services.AddSingleton<InsertOutboxMessagesInterceptor>();

        //persistence
        string? connectionString = configuration.GetConnectionString("Database");
        Ensure.NotNullOrEmpty(connectionString);
        services.AddTransient(_ => new DbConnectionFactory(connectionString));
        services.AddDbContext<ApplicationCommandDbContext>((sp, options) => options.UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //search
        services.Configure<ElasticSettings>(configuration.GetSection("Elasticsearch"));

        services.AddSingleton<ElasticsearchClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<ElasticSettings>>().Value;

            var clientSettings = new ElasticsearchClientSettings(new Uri(settings.Url))
                .Authentication(new BasicAuthentication(settings.Username, settings.Password))
                .DefaultIndex(settings.DefaultIndex);

            return new ElasticsearchClient(clientSettings);
        });
        //caching
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });
        services.AddScoped<IRedisCacheService, RedisCacheService>();

        //payment
        services.AddScoped<IPaymentGatewayService, MoMoGatewayService>();
        //services.AddScoped<IPaymentGatewayService, VnPayGatewayService>();

        

        //outbox
        services.AddHostedService<OutboxMessagePublisher>(); // Singleton


        //notifi
        services.AddTransient<INotificationService, NotificationService>();


        //messenger broker
        services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.AddConsumers(typeof(AppointmentCreatedEventConsumer).Assembly);

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

                configurator.Host(new Uri(settings.Host), h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                configurator.ConfigureEndpoints(context);
            });
        });
        services.AddTransient<IEventBus, EventBus>();

        //authen and author
       services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
        var secretKeyBytes = Encoding.UTF8.GetBytes(jwtSettings.Key);

       services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;

            // Configure event handlers for JWT authentication
            //options.Events = new JwtBearerEvents
            //{

            //    OnTokenValidated = context =>
            //    {
            //        // Log successful token validation
            //        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            //        logger.LogInformation("Token validated successfully");

            //        // Ensure roles are properly handled from the token
            //        var userIdClaim = context.Principal.FindFirst(ClaimTypes.NameIdentifier);
            //        if (userIdClaim != null)
            //        {
            //            logger.LogInformation($"Authenticated user ID: {userIdClaim.Value}");
            //        }

            //        // Log roles for debugging
            //        var roleClaims = context.Principal.FindAll(ClaimTypes.Role);
            //        foreach (var roleClaim in roleClaims)
            //        {
            //            logger.LogInformation($"User has role: {roleClaim.Value}");
            //        }

            //        return Task.CompletedTask;
            //    },
            //    OnAuthenticationFailed = context =>
            //    {
            //        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            //        logger.LogError($"Authentication failed: {context.Exception.Message}");
            //        return Task.CompletedTask;
            //    },
            //    OnChallenge = context =>
            //    {
            //        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            //        logger.LogWarning("Authentication challenge issued");
            //        return Task.CompletedTask;
            //    }
            //};

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudience = jwtSettings.Audience,
                ValidIssuer = jwtSettings.Issuer,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                // Use the exact claim type mapping for role claims
                RoleClaimType = ClaimTypes.Role,
                NameClaimType = ClaimTypes.Name,
                ClockSkew = TimeSpan.Zero
            };
        });

        // Add authorization policies for Vietnamese role names
       services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Quản trị viên"));
            options.AddPolicy("RequireDoctorRole", policy => policy.RequireRole("Bác sĩ"));
            options.AddPolicy("RequirePatientRole", policy => policy.RequireRole("Bệnh nhân"));
            options.AddPolicy("RequireReceptionistRole", policy => policy.RequireRole("Lễ tân"));
            options.AddPolicy("RequireGuardianRole", policy => policy.RequireRole("Người giám hộ"));
        });

    }
}
