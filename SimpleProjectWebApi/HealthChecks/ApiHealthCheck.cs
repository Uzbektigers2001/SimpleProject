using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SimpleProjectWebApi.HealthChecks
{
    public class ApiHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await IsApiWorking() ? HealthCheckResult.Healthy("Connection is Ok") : HealthCheckResult.Unhealthy("Error");
        }

        private async Task<bool> IsApiWorking()
        {
            HttpClient client= new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

            var result = await client.GetAsync(new Uri("https://localhost:6001/api/Main/GetAll"));
            return result.EnsureSuccessStatusCode().IsSuccessStatusCode ? await Task.FromResult(true) : await Task.FromResult(false);

        }
    }
}
