using astroProject_service.Entities;
using astroProject_service.Models;
using astroProject_service.Models.RequestModels;
using astroProject_service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace astroProject_service.Controllers

{
    [ApiController, Route("api/v1/astroProject-service/[controller]/[action]")]
    public class NatalChartController : ControllerBase
    {
        private readonly NatalChartService natalChartService;
        private readonly AppDbContext appDbContext;
        public NatalChartController(
            NatalChartService natalChartService,
            AppDbContext appDbContext
            )
        {
            this.natalChartService = natalChartService;
            this.appDbContext = appDbContext;
        }
    }
}
