using astroProject_service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace iks_endeks_service.Services
{
    public class ZodiacStreamService : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private bool dailyUpdated = false;
        private bool weeklyUpdated = false;
        private bool monthlyUpdated = false;
        private bool yearlyUpdated = false;


        public ZodiacStreamService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Türkiye
                var now = DateTime.UtcNow.AddHours(3);

                if (now.Hour == 5 && now.Minute == 0 && !dailyUpdated)
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var zodiacService = scope.ServiceProvider.GetRequiredService<ZodiacService>();
                        await zodiacService.CreateDailyZodiacSignStreamData();
                    }
                    dailyUpdated = true;
                }

                if (now.DayOfWeek == DayOfWeek.Monday && now.Hour == 5 && now.Minute == 0 && !weeklyUpdated)
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var zodiacService = scope.ServiceProvider.GetRequiredService<ZodiacService>();
                        await zodiacService.CreateWeeklyZodiacSignStreamData();
                    }
                    weeklyUpdated = true;
                }

                if (now.Day == 1 && now.Hour == 5 && now.Minute == 0 && !monthlyUpdated)
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var zodiacService = scope.ServiceProvider.GetRequiredService<ZodiacService>();
                        await zodiacService.CreateMonthlyZodiacSignStreamData();
                    }
                    monthlyUpdated = true;
                }

                if (now.Month == 1 && now.Day == 1 && now.Hour == 5 && now.Minute == 0 && !yearlyUpdated)
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var zodiacService = scope.ServiceProvider.GetRequiredService<ZodiacService>();
                        await zodiacService.CreateYearlyZodiacSignStreamData();
                    }
                    yearlyUpdated = true;
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
