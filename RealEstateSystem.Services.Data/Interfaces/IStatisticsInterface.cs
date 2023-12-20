using RealEstateSystem.Models.ViewModels.Stastic;


namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface IStatisticsInterface
    {
        Task<StatisticServiceViewModel> GetStatisticsAsync();

    }
}
