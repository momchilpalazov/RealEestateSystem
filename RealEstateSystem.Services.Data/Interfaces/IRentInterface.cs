using RealEstateSystem.Models.ViewModels.Rent;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public  interface IRentInterface
    {
        Task<IEnumerable<RentServiceViewModel>>All();

    }
}
