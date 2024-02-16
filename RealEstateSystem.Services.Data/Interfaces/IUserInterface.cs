using RealEstateSystem.Models.ViewModels.User;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public  interface IUserInterface
    {

        Task <string> UserFullName(Guid userId);

        Task <IEnumerable<UserServiceViewModel>> All();

        Task<bool> UserHasRent(Guid userId);


    }
}
