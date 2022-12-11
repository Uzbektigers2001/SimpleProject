using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SimpleProjectMVC.HealthChecks
{
    public class HealthChecker : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await IsWorking() ? HealthCheckResult.Healthy("Working") : HealthCheckResult.Unhealthy("Error");
        }

        private Task<bool> IsWorking()
        {
            return DateTime.Now.Millisecond % 2 == 1 ? Task.FromResult(true) : Task.FromResult(false);
        }

    }
}
