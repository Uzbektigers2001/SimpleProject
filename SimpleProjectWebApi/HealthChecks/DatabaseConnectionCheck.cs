using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SimpleProject.Data;

namespace SimpleProjectWebApi.HealthChecks
{
    public class DatabaseConnectionCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await IsConnected() ? HealthCheckResult.Healthy("Connection is Ok") : HealthCheckResult.Unhealthy("Error");
        }

        private Task<bool> IsConnected()
        {
            try
            {
                var connection = new SqlConnection("Product");
                connection.Open();

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }

    
}
