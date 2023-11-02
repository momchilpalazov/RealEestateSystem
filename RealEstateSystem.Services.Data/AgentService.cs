using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<bool> ExistUserByPhoneNumber(string phoneNumber)
        {
            var existUser = this.db.Agents.AnyAsync(x => x.PhoneNumber == phoneNumber);

            return existUser;
        }

        public Task<bool> UsreHasRent(Guid userId)
        {
            var hasRent = this.db.Hauses.AnyAsync(x => x.RenterId == userId);  

            return hasRent;
        }
    }
}
