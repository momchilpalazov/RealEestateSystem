using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Tests.Mocks;


namespace RealEstateSystem.Tests.UnitTests
{
    public class UnitTestsBase
    {
       
        protected RealEstateSystemDbContext db;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            db = DatabaseMock.Instance;
            SeedDataBase();
        }

        public ApplicationUser RenterUser { get; private set; }

        public ApplicationUser AgentUser { get; private set; }

        public Agent Agent { get; private set; }

        public House RentedHouse { get; private set; }

        private void SeedDataBase()
        {

            AgentUser = new ApplicationUser
            {
                UserName = "agent@admin.com",
                NormalizedUserName = "AGENT@ADMIN.COM",
                Email = "agent@admin.com",
                NormalizedEmail = "AGENT@ADMIN.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEFr9D5AEcyY0SvJzTSLuBJD70lhK7S9gI7CnK95NhvWs4JvyHcRSL6aMdjZKQozNKg==",
                ConcurrencyStamp = "4bb52207-b0d7-40d1-90bf-c066e2508332",
                SecurityStamp = "0",
                TwoFactorEnabled = false,
                FirstName = "Admin",
                LastName = "Adminov",
            };
            db.Users.Add(AgentUser);    


            RenterUser = new ApplicationUser
            {
                UserName = "renter@renter.com",
                NormalizedUserName = "RENTER@RENTER.COM",             
                Email = "renter@renter.com",
                NormalizedEmail = "RENTER@RENTER.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEKGaysNwSV1Iim/Vd/VsDMCTbNpwEiL6wvIUyli06XF4H/LtirsLNk8y26agMWarEQ==",
                ConcurrencyStamp = "9cc5edf7-80b5-4dba-aa88-06908ee0814c",
                SecurityStamp = "0",
                TwoFactorEnabled = false,
                FirstName = "Admin",
                LastName = "Adminov",
               

            };

            db.Users.Add(RenterUser);


            Agent = new Agent
            {
                Id= Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f"),
                PhoneNumber = "+4915227452539",
                UserId = Agent.Id
            };

            db.Agents.Add(Agent);

            RentedHouse = new House
            {
                Id = Guid.Parse("HouseId"),              
                Description = "House",
                Address = "Address",
                Title = "https://media.bonava.de/2869278/version/3/element/actual/0/storage/web-image/file/05939880.jpg",
                ImageUrl = "ImageUrl",
                Renter= RenterUser,
                Agent = Agent,                
                AgentId = Agent.Id,
                Category = new Category
                {                    
                    Name = "Category"
                },

            };

            db.Hauses.Add(RentedHouse);

            var nonRentedHouse = new House
            {
                Id = Guid.Parse("NonRentedHouseId"),
                Description = "House",
                Address = "Address",
                Title = "https://media.bonava.de/2869278/version/3/element/actual/0/storage/web-image/file/05939880.jpg",
                ImageUrl = "ImageUrl",
                Category = new Category
                {
                    Name = "Category"
                },

            };

            db.Hauses.Add(nonRentedHouse);
            db.SaveChanges();

        }

        [OneTimeSetUp]
        public void TearDownBase()
        {
            db.Dispose();
        }   



    }
}
