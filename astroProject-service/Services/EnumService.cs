using Azure.Core;
using astroProject_service.Entities;
using astroProject_service.Models.RequestModels;
using astroProject_service.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using astroProject_service.Entities.EnumModels;

namespace astroProject_service.Services
{
    public class EnumService
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext appDbContext;

        public EnumService(IConfiguration configuration, AppDbContext appDbContext)
        {
            this.configuration = configuration;
            this.appDbContext = appDbContext;
        }

        public async Task<List<RelationshipEntity>> GetRelationships()
        {
            return await appDbContext.Relationship.ToListAsync();
        }

        public async Task<List<MembershipEntity>> GetMemberships()
        {
            return await appDbContext.Membership.ToListAsync();
        }

        public async Task<List<ZodiacEntity>> GetZodiacs()
        {
            return await appDbContext.Zodiac.ToListAsync();
        }
    }
}

