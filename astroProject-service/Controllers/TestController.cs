using astroProject_service.Models;
using astroProject_service.Models.RequestModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace astroProject_service.Controllers

{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ZodiacService zodiacService;
        private readonly TarotService tarotService;

        public TestController(
            ZodiacService zodiacService,
            TarotService tarotService
            )
        {
            this.zodiacService = zodiacService;
            this.tarotService = tarotService;
        }


        [HttpGet]
        public async Task<ActionResult<bool>> Test()
        {
            var result = await tarotService.CreateTarotCardsAsync();
            return Ok(result);
        }
    }
}
