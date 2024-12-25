using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace astroProject_service.Services.SingleRunServices
{
    public abstract class SingleRunService : IHostedService
    {

        protected SingleRunService()
        {
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {

                await ExecuteOnceAsync(cancellationToken);

            }
            catch (Exception ex)
            {
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected abstract Task ExecuteOnceAsync(CancellationToken cancellationToken);
    }
}
