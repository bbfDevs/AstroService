using astroProject_service.Models.RequestModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace astroProject_service.Controllers
{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class TextGeneratorController : ControllerBase
    {
        private readonly TextGeneratorService textGeneratorService;
        public TextGeneratorController(TextGeneratorService textGeneratorService)
        {
            this.textGeneratorService = textGeneratorService;

        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTextFromPrompt(TextGeneratorRequest textGeneratorRequest)
        {
            var result = await textGeneratorService.CreateTextFromPromptAsync(textGeneratorRequest);
            return result;
        }
    }
}
