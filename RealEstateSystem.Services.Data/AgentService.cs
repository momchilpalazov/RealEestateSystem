using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Services.Data.Interfaces;


namespace RealEstateSystem.Services.Data
{
    public class AgentServiceIndex : IAgentInterface
    {
        private readonly RealEstateSystemDbContext db;

        public AgentServiceIndex(RealEstateSystemDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Guid userId, string phoneNumber)
        {

            var agent = new Agent
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await this.db.Agents.AddAsync(agent);
            await this.db.SaveChangesAsync();

        }

        public async Task<bool> ExistById(Guid userId)
        {

            var agent = await this.db.Agents.AnyAsync(x => x.UserId == userId); 

            return agent;           
           
        }

        public async Task<bool> ExistUserByPhoneNumber(string phoneNumber)
        {
            var existUser = await this.db.Agents.AnyAsync(x => x.PhoneNumber == phoneNumber);

            return existUser;
        }

       

        public async Task<bool> UserHasRent(Guid userId)
        {
            var hasRent = await this.db.Hauses.AnyAsync(x => x.RenterId == userId);  

            return hasRent;
        }

       

        public async Task<string> GetAgentId(Guid agentId)
        {
            var agent = await this.db.Agents.Where(x => x.UserId == agentId).Select(x => x.Id).FirstOrDefaultAsync();

            return  agent.ToString();

           
           
        }
    }
}
