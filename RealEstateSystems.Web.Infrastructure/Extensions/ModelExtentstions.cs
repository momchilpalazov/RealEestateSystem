using RealEstateSystems.Web.Infrastructure.Extensions.Contracts;
using System.Text.RegularExpressions;

namespace RealEstateSystems.Web.Infrastructure.Extensions
{
    public static class ModelExtentstions
    {

        public static string GetInformationAboutHouse(IHouseModelInterface house)
        {
            return house.Title.Replace(" ", "-") + "_" + GetAddress(house.Address);
        }

        private static string GetAddress(string address)
        {
            
            address=String.Join("-", address.Split(" ").Take(3));
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);


        }
    }
}
