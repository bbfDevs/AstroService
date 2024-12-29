using astroProject_service.Models;
using astroProject_service.Models.RequestModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace astroProject_service.Controllers

{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class TarotController : ControllerBase
    {
        private readonly TarotService tarotService;
        public TarotController(TarotService tarotService)
        {
            this.tarotService = tarotService;

        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateTarotReading(TarotRequest tarotRequest)
        {
            var result = await tarotService.CreateTarotReadingAsync(tarotRequest);
            return Ok(result);
        }
    }
}
