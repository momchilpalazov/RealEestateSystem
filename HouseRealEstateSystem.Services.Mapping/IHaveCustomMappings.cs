using AutoMapper;


namespace HouseRealEstateSystem.Services.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
