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

        Task<bool> ExistUserByPhoneNumber(string phoneNumber);

        Task<bool> UsreHasRent(Guid userId);

        Task  Create(Guid userId, string phoneNumber);
    }
}
