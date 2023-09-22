using Microsoft.Extensions.Configuration;

namespace EgretApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DbConnectionString { get => _configuration.GetConnectionString("DefaultConnection"); }
    }

}
