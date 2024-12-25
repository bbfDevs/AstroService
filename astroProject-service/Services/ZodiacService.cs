using Azure.Core;
using astroProject_service.Entities;
using astroProject_service.Models.RequestModels;
using astroProject_service.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace astroProject_service.Services
{
    public class ZodiacService
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext appDbContext;
        private readonly TextGeneratorService textGeneratorService;

        public ZodiacService(
            IConfiguration configuration,
            AppDbContext appDbContext,
            TextGeneratorService textGeneratorService
            )
        {
            this.configuration = configuration;
            this.appDbContext = appDbContext;
            this.textGeneratorService = textGeneratorService;
        }

        #region Zodiac Sign Stream Creation
        public async Task<string> GetZodiacSignStreamPrompt(string zodiacSign, string category, string period)
        {
            string prompt = $@"
                In your message only include the horoscope description. Just write the horoscope description.
                You are an expert astrologer tasked with providing a detailed horoscope for a specific zodiac sign, category, and period. The horoscope should be concise, 4-5 sentences. Please ensure the horoscope reflects the astrological influences and personality traits of the zodiac sign during this period.
                About 
                        {zodiacSign} {period} {category} Horoscope:
                ### Zodiac Sign: 
                        {zodiacSign}
                ### Category: 
                        {category}
                ### Period: {period}

                The reading should:
                - Be insightful and reflective of the zodiac sign's traits.
                - Take into account the period (e.g., daily influences vs. long-term influences).
                - Offer guidance, advice, and any important astrological factors that may affect the individual during this period.
                - Keep the tone positive, motivating, and empowering, ensuring that the individual feels supported and informed.

                Please provide only the horoscope description.";
            return prompt;
        }
        public async Task<bool> CreateDailyZodiacSignStreamData()
        {
            try
            {
                var existingData = await appDbContext.ZodiacSignStream
                    .Where(x => x.Period == "Daily")
                    .Where(x => x.Date.Day == DateTime.UtcNow.AddHours(3).Day)
                    .ToListAsync();
                if (existingData.Count > 0)
                {
                    return true;
                }
                var result = new List<ZodiacSignStream>();
                foreach (var zodiacSign in Enum.GetValues(typeof(ZodiacSignEnum)).Cast<ZodiacSignEnum>())
                {
                    foreach (var catagory in Enum.GetValues(typeof(LifeAspectsEnum)).Cast<LifeAspectsEnum>())
                    {
                        var zodiacSignData = new ZodiacSignStream
                        {
                            Name = zodiacSign.ToString(),
                            Catagory = catagory.ToString(),
                            Period = "Daily",
                            Date = DateTime.UtcNow.AddHours(3)
                        };
                        var prompt = await GetZodiacSignStreamPrompt(zodiacSign.ToString(), catagory.ToString(), "Daily");

                        string rawResponse = await textGeneratorService.CreateTextFromPromptAsync(new TextGeneratorRequest
                        {
                            Prompt = prompt,
                            Model = "openai",
                            Seed = 42
                        });

                        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(rawResponse);
                        zodiacSignData.Description = jsonResponse.horoscope.ToString();

                        result.Add(zodiacSignData);
                    }
                }
                await appDbContext.ZodiacSignStream.AddRangeAsync(result);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public async Task<bool> CreateWeeklyZodiacSignStreamData()
        {
            try
            {
                var existingData = await appDbContext.ZodiacSignStream
                    .Where(x => x.Period == "Weekly")
                    .Where(x => x.Date.DayOfWeek == DateTime.UtcNow.AddHours(3).DayOfWeek)
                    .ToListAsync();
                if (existingData.Count > 0)
                {
                    return true;
                }
                var result = new List<ZodiacSignStream>();
                foreach (var zodiacSign in Enum.GetValues(typeof(ZodiacSignEnum)).Cast<ZodiacSignEnum>())
                {
                    foreach (var catagory in Enum.GetValues(typeof(LifeAspectsEnum)).Cast<LifeAspectsEnum>())
                    {
                        var zodiacSignData = new ZodiacSignStream
                        {
                            Name = zodiacSign.ToString(),
                            Catagory = catagory.ToString(),
                            Period = "Weekly",
                            Date = DateTime.UtcNow.AddHours(3)
                        };
                        var prompt = await GetZodiacSignStreamPrompt(zodiacSign.ToString(), catagory.ToString(), "Weekly");
                        zodiacSignData.Description = await textGeneratorService.CreateTextFromPromptAsync(new TextGeneratorRequest
                        {
                            Prompt = prompt,
                            Model = "openai",
                            Seed = 42
                        });
                        result.Add(zodiacSignData);
                    }
                }
                await appDbContext.ZodiacSignStream.AddRangeAsync(result);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public async Task<bool> CreateMonthlyZodiacSignStreamData()
        {
            try
            {
                var existingData = await appDbContext.ZodiacSignStream
                    .Where(x => x.Period == "Monthly")
                    .Where(x => x.Date.Month == DateTime.UtcNow.AddHours(3).Month)
                    .ToListAsync();
                if (existingData.Count > 0)
                {
                    return true;
                }
                var result = new List<ZodiacSignStream>();
                foreach (var zodiacSign in Enum.GetValues(typeof(ZodiacSignEnum)).Cast<ZodiacSignEnum>())
                {
                    foreach (var catagory in Enum.GetValues(typeof(LifeAspectsEnum)).Cast<LifeAspectsEnum>())
                    {
                        var zodiacSignData = new ZodiacSignStream
                        {
                            Name = zodiacSign.ToString(),
                            Catagory = catagory.ToString(),
                            Period = "Monthly",
                            Date = DateTime.UtcNow.AddHours(3)
                        };
                        var prompt = await GetZodiacSignStreamPrompt(zodiacSign.ToString(), catagory.ToString(), "Monthly");
                        zodiacSignData.Description = await textGeneratorService.CreateTextFromPromptAsync(new TextGeneratorRequest
                        {
                            Prompt = prompt,
                            Model = "openai",
                            Seed = 42
                        });
                        result.Add(zodiacSignData);
                    }
                }
                await appDbContext.ZodiacSignStream.AddRangeAsync(result);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public async Task<bool> CreateYearlyZodiacSignStreamData()
        {
            try
            {
                var existingData = await appDbContext.ZodiacSignStream   
                    .Where(x => x.Period == "Yearly")
                    .Where(x => x.Date.Year == DateTime.UtcNow.AddHours(3).Year)
                    .ToListAsync();
                if (existingData.Count > 0)
                {
                    return true;
                }
                var result = new List<ZodiacSignStream>();
                foreach (var zodiacSign in Enum.GetValues(typeof(ZodiacSignEnum)).Cast<ZodiacSignEnum>())
                {
                    foreach (var catagory in Enum.GetValues(typeof(LifeAspectsEnum)).Cast<LifeAspectsEnum>())
                    {
                        var zodiacSignData = new ZodiacSignStream
                        {
                            Name = zodiacSign.ToString(),
                            Catagory = catagory.ToString(),
                            Period = "Yearly",
                            Date = DateTime.UtcNow.AddHours(3)
                        };
                        var prompt = await GetZodiacSignStreamPrompt(zodiacSign.ToString(), catagory.ToString(), "Yearly");
                        zodiacSignData.Description = await textGeneratorService.CreateTextFromPromptAsync(new TextGeneratorRequest
                        {
                            Prompt = prompt,
                            Model = "openai",
                            Seed = 42
                        });
                        result.Add(zodiacSignData);
                    }
                }
                await appDbContext.ZodiacSignStream.AddRangeAsync(result);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        #endregion
    }
}

