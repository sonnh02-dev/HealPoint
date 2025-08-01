using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Caching
{
    public interface IRedisCacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync(string key, object value, TimeSpan? expiry = null);
        Task RemoveAsync(string key);
    }
}
