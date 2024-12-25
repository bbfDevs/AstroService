using System;
using System.Threading;
using System.Threading.Tasks;
using astroProject_service.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace astroProject_service.Services.SingleRunServices
{
    public class DataGeneratorService : SingleRunService
    {
        private readonly IServiceProvider iServiceProvider;

        public DataGeneratorService(
            IServiceProvider iServiceProvider
            )
        {
            this.iServiceProvider = iServiceProvider;
        }

        protected override async Task ExecuteOnceAsync(CancellationToken cancellationToken)
        {
            try
            {

                using (var scope = iServiceProvider.CreateScope())
                {
                    var tarotService = scope.ServiceProvider.GetRequiredService<TarotService>();
                    await tarotService.CreateTarotCardsAsync();
                }

                await Task.Delay(2000, cancellationToken); 

            }
            catch (Exception ex)
            {
             
            }
        }
    }
}
