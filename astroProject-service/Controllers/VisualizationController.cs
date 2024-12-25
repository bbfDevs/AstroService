using astroProject_service.Models.RequestModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace astroProject_service.Controllers

{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class VisualizationController : ControllerBase
    {
        private readonly VisualizationService visualizationService;
        public VisualizationController(VisualizationService visualizationService)
        {
            this.visualizationService = visualizationService;

        }

        [HttpPost]
        public async Task<ActionResult> CreateImageFromPrompt(ImageRequest imageRequest)
        {
            byte[]? result = await visualizationService.CreateImageFromPrompt(imageRequest);

            return result != null ? File(result, "image/png") : StatusCode(500);
        }
    }
}
