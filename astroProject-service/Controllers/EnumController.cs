using astroProject_service.Entities.EnumModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace astroProject_service.Controllers

{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class EnumController : ControllerBase
    {
        private readonly EnumService enumService;
        public EnumController(EnumService enumService)
        {
            this.enumService = enumService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RelationshipEntity>>> GetRelationships()
        {
            return await enumService.GetRelationships();
        }

        [HttpGet]
        public async Task<ActionResult<List<MembershipEntity>>> GetMemberships()
        {
            return await enumService.GetMemberships();
        }

        [HttpGet]
        public async Task<ActionResult<List<ZodiacEntity>>> GetZodiacs()
        {
            return await enumService.GetZodiacs();
        }

        [HttpGet]
        public async Task<ActionResult<List<LifeAspectEntity>>> GetLifeAspects()
        {
            return await enumService.GetLifeAspects();
        }

        public async Task<ActionResult<List<TarotCardEntity>>> GetTarotCards()
        {
            return await enumService.GetTarotCards();
        }
    }
}
