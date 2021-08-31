using Microsoft.Extensions.Configuration;

namespace HC_Automapper_Issue.Services
{
    public class ConnectionStringService : IConnectionStringService
    {
        readonly string _connectionStringServiceUrl;
        public ConnectionStringService(IConfiguration configuration)
        {
            _connectionStringServiceUrl = configuration["ConnectionString"];
        }

        public string GetDbConnectionString()
        {
            return _connectionStringServiceUrl;
        }
    }
}