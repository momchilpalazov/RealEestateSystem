using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Agents;
using RealEstateSystem.Services.Data.Interfaces;


namespace RealEstateSystem.Services.Data
{
    public class AgentService : IAgentInterface
    {
        private readonly RealEstateSystemDbContext db;

        public AgentService(RealEstateSystemDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Guid userId, BecomeAgentFormModel model)
        {

            var agent = new Agent
            {
                UserId = userId,
                PhoneNumber = model.PhoneNumber
            };

            await this.db.Agents.AddAsync(agent);
            await this.db.SaveChangesAsync();

            

        }

        public async Task<bool> ExistById(Guid userId)
        {

            var agent = await this.db.Agents.AnyAsync(x => x.UserId == userId); 

            return agent;           
           
        }

        public async Task<bool> ExistAgentByPhoneNumber(string phoneNumber)
        {
            var existUser = await this.db.Agents.AnyAsync(x => x.PhoneNumber == phoneNumber);

            return existUser;
        }   

       

        public async Task<string> GetAgentId(Guid agentId)
        {
            var agent = await this.db.Agents.Where(x => x.UserId == agentId).Select(x => x.Id).FirstOrDefaultAsync();

            return  agent.ToString();

           
           
        }
    }
}
