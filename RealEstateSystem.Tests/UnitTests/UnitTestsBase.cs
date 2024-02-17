using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Tests.Mocks;


namespace RealEstateSystem.Tests.UnitTests
{
    public class UnitTestsBase
    {
       
        protected RealEstateSystemDbContext db;

        [SetUp]
        public void SetUpBase()
        {
            db = DatabaseMock.Instance;
            SeedDataBase();
        }

        public ApplicationUser RenterUser { get; private set; }

        public ApplicationUser AgentUser { get; private set; }

        public Agent Agent { get; private set; }

        public House RentedHouse { get; private set; }

        public void SeedDataBase()
        {

            AgentUser = new ApplicationUser
            {
                Id = Guid.Parse("e64b19bf-ec2b-43a8-a5f2-ee94197cd191"),
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
                Id = Guid.Parse("5e993eee-ffbb-48dc-8e4d-b1a73056fa8a"),
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
               
                Id = Guid.NewGuid(),
                PhoneNumber = "+4915227452539",
                UserId = AgentUser.Id,
                User = AgentUser
             

            };

            db.Agents.Add(Agent);

            RentedHouse = new House
            {
                Id = Guid.Parse("83af2ef0-21a4-4bd8-9106-b66b8c413940"),              
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
                Id = Guid.Parse("27f0a41c-6451-4a14-a73a-7d7ed11d8ec9"),
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

        [TearDown]
        public void TearDownBase()
        {
            db.Dispose();
        }



    }
}
