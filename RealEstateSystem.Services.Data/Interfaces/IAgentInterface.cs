using RealEstateSystem.Models.ViewModels.Agents;
using RealEstateSystem.Models.ViewModels.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface IAgentInterface
    {
        Task<bool> ExistById(Guid userId);

        Task<bool> ExistAgentByPhoneNumber(string phoneNumber);  

        Task  Create(Guid userId, BecomeAgentFormModel model);
        Task <string> GetAgentId(Guid agentId);


    }
}
