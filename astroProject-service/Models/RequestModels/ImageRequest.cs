namespace astroProject_service.Models.RequestModels
{
    public class ImageRequest
    {
        public required string Prompt { get; set; }

        public string Model { get; set; } = "turbo";

        public int Seed { get; set; } = 42;

        public int Width { get; set; } = 1024;

        public int Height { get; set; } = 1024;
    }
}
