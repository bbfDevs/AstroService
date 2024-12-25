using astroProject_service.Models.RequestModels;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace astroProject_service.Services
{
    public class TextGeneratorService
    {
        private readonly IConfiguration configuration;

        public TextGeneratorService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTextFromPromptAsync(TextGeneratorRequest textGeneratorRequest)
        {
            try
            {
                string apiUrl = Constants.POLLINATIONS_API_TEXT_URL;

                using var httpClient = new HttpClient();
                var requestBody = new
                {
                    model = textGeneratorRequest.Model,
                    seed = textGeneratorRequest.Seed,
                    jsonMode = true,
                    messages = new[]
                    {
                        new { role = "user", content = textGeneratorRequest.Prompt }
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Pollinations API error: {response.ReasonPhrase}, Details: {errorDetails}");
                }

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while communicating with OpenAI API: {ex.Message}", ex);
            }

        }
    }
}

