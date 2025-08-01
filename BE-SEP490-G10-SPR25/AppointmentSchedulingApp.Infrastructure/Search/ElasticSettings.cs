using Microsoft.Extensions.Options;

namespace AppointmentSchedulingApp.Infrastructure.Search
{
    public class ElasticSettings
    {
        public string Url { get; set; } = string.Empty;
        public string DefaultIndex { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
