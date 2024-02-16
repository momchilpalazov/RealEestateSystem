using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;


namespace RealEstateSystem.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static RealEstateSystemDbContext Instance
        {


            get
            {
                var options = new DbContextOptionsBuilder<RealEstateSystemDbContext>()
                    .UseInMemoryDatabase(databaseName: "RealEstateSystemTest"+
                    DateTime.Now.Ticks.ToString())  
                    .Options;

                return new RealEstateSystemDbContext(options,false);
            }


            
        }



    }
}
