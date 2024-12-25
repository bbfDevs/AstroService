namespace astroProject_service.Models.RequestModels
{
    public class TextGeneratorRequest
    {
        public required string Prompt { get; set; }

        public string Model { get; set; } = "openai";

        public int Seed { get; set; } = 42;
    }
}
