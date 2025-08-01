using AppointmentSchedulingApp.Application.Abstractions.Caching;


using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.MessageBroker.Consumers
{
    public class CacheSetRequestConsumer : IConsumer<CacheSetRequest>
    {
        private readonly IRedisCacheService _cacheService;

        public CacheSetRequestConsumer(IRedisCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task Consume(ConsumeContext<CacheSetRequest> context)
        {
            var message = context.Message;        
            //await _cacheService.SetAsync(message.Key, message.Value, message.Expiry);
        }
    }



}
