using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using AppointmentSchedulingApp.Infrastructure;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);


//ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
//modelBuilder.EntitySet<ReservationDTO>("Reservations");
//modelBuilder.EntitySet<DoctorDTO>("Doctors");
//modelBuilder.EntitySet<PatientDTO>("Patients");
//modelBuilder.EntitySet<SpecialtyQueryModel>("Specialties");
//modelBuilder.EntitySet<ServiceDTO>("Services");
//modelBuilder.EntitySet<FeedbackDTO>("Feedbacks");
//modelBuilder.EntitySet<UserQueryModel>("Users");
//modelBuilder.EntitySet<DoctorScheduleDTO>("DoctorSchedules");
//builder.Services.AddControllers().AddOData(opt => opt.Select().Filter().SetMaxTop(100).Expand().OrderBy().Count().AddRouteComponents("odata", modelBuilder.GetEdmModel()));


//var provider = builder.Services.BuildServiceProvider();
//var config = provider.GetService<IConfiguration>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(builder.Configuration["FrontendUrl"])
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                });
});









//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddScoped<IReservationService, ReservationService>();

//// Đăng ký repository generic
//builder.Services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericCommandRepository<>));

//// Đăng ký các dịch vụ khác
//builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
//builder.Services.AddScoped<IMedicalReportService, MedicalReportService>();
//builder.Services.AddScoped<IDoctorService, DoctorService>();
//builder.Services.AddScoped<IPatientService, PatientService>();
//builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
//builder.Services.AddScoped<IServiceService, ServiceService>();
//builder.Services.AddScoped<IPostService, PostService>();
//builder.Services.AddScoped<IFeedbackService, FeedbackService>();
//builder.Services.AddScoped<IStorageService, StorageService>();
//builder.Services.AddScoped<ICommentService, CommentService>();
//builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
//builder.Services.AddScoped<IRoomService, RoomService>();
//builder.Services.AddScoped<ISlotService, SlotService>();

//// Đăng ký các dịch vụ liên quan đến người dùng
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IRoleService, RoleService>();
//builder.Services.AddScoped<IGenericCommandRepository<User>, GenericCommandRepository<User>>();
//builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();

//builder.Services.AddScoped<IPaymentService, PaymentService>();
//builder.Services.AddScoped<IPaymentGatewayService, MoMoGatewayService>();
//builder.Services.AddScoped<IPaymentGatewayService, VnPayGatewayService>();
//builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

//builder.Services.AddScoped<INotificationService, AppointmentSchedulingApp.Presentation.Hubs.SignalRNotificationService>();

//builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();




// Add Email Configs
//var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfigurationDTO>();
//builder.Services.AddSingleton(emailConfig);

// Đăng ký các service
//builder.Services.AddScoped<IAIAgentService, AIAgentService>();
//builder.Services.AddScoped<IChatService, ChatService>();

//Đăng ký SignalR
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
    options.KeepAliveInterval = TimeSpan.FromMinutes(15);
    options.HandshakeTimeout = TimeSpan.FromMinutes(5);
    options.MaximumReceiveMessageSize = 1024 * 1024; // 1MB
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Sử dụng chính sách CORS mới
app.UseCors("AllowAll");
app.MapGet("/healthz", () => "Healthy");

// app.UseHttpsRedirection(); // Tạm thời vô hiệu hóa để tránh lỗi HTTPS port
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.MapHub<CommentHub>("/hubs/comments")
//   .RequireCors("AllowAll");

//app.MapHub<NotificationHub>("/hubs/notifications")
//   .RequireCors("AllowAll");

//app.MapHub<NotificationHub>("/hubs/notification")
//   .RequireCors("SignalRCorsPolicy");

app.Run();