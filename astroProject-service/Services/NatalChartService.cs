using astroProject_service.Models.RequestModels;
using System.Text.Json;
using SwissEphNet;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using astroProject_service.Models;
using System.Xml.Linq;
using Microsoft.Identity.Client;
using astroProject_service.Entities;

namespace astroProject_service.Services
{

    public class NatalChartService
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;
        private readonly TextGeneratorService textGeneratorService;

        public NatalChartService(
            IConfiguration configuration,
            TextGeneratorService textGeneratorService,
            AppDbContext appDbContext
            )
        {
            this.configuration = configuration;
            this.textGeneratorService = textGeneratorService;
            this.appDbContext = appDbContext;
        }
    }
}
