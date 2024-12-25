using astroProject_service.Models.RequestModels;

namespace astroProject_service.Services
{
    public class VisualizationService
    {
        private readonly IConfiguration configuration;

        public VisualizationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<byte[]?> CreateImageFromPrompt(ImageRequest imageRequest)
        {
            try
            {
                using HttpClient httpClient = new();
                string requestUri = CreateRequestUrlFromParams(imageRequest);

                HttpResponseMessage response = await httpClient.GetAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    return null;
                }

                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
                return responseBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured in {nameof(CreateImageFromPrompt)} : {ex}");

                return null;
            }

        }

        private string CreateRequestUrlFromParams(ImageRequest imageRequest)
        {
            string baseUrl = Constants.POLLINATIONS_API_IMAGE_URL + "/prompt/";
            string prompt = Uri.EscapeDataString(imageRequest.Prompt);

            string requestUri = $"{baseUrl}{prompt}?width={imageRequest.Width}&height={imageRequest.Height}&model={imageRequest.Model}&seed={imageRequest.Seed}&nologo=true";

            return requestUri;
        }
    }
}
