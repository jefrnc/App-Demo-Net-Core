using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyAppWeb.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppWeb.Mock
{
    public class RandomHealthCheck : IHealthCheck
    {
        private static readonly Random _rnd = new Random();



        

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var result = HealthCheckResult.Healthy();
            if (BombModel.IsBroken)
                result = HealthCheckResult.Unhealthy("Failed ");
      
            return Task.FromResult(result);
        }
    }
}
