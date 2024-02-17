using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystem.Tests.UnitTests;
using RealEstateSystem.Services.Data;
using RealEstateSystem.Models.ViewModels.Agents;


namespace RealEstateSystem.Tests
{
    [TestFixture]
    public class AgentServiceTests: UnitTestsBase
    {
        private IAgentInterface agentService; 


        [SetUp]
        public void Setup()
        {
                                
            agentService = new AgentService(db);
            
        }



        [Test]
        public async Task GetAgentId_ShouldReturnAgentId()
        {


            var resultId = await agentService.GetAgentId(Agent.UserId);


            Assert.That(resultId, Is.EqualTo(Agent.Id.ToString()));


        }

        [Test]
        public async Task ExistById_ShouldReturnTrue()
        {
            var result = await agentService.ExistById(AgentUser.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistAgentByPhoneNumber_ShouldReturnTrue()
        {
            var result = await agentService.ExistAgentByPhoneNumber(Agent.PhoneNumber);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task Create_ShouldCreateAgent()
        {
            var agentCountBefore = db.Agents.Count();

            await agentService.Create(Agent.Id, new BecomeAgentFormModel 
            {
                PhoneNumber = "088888888888"
            });  
            
            var newAgentCountAfter = db.Agents.Count();

            Assert.That(newAgentCountAfter, Is.EqualTo(agentCountBefore + 1)); 
            
            var newAgentId= await agentService.GetAgentId(Agent.UserId);
            var newAgentInDb=db.Agents.FindAsync(Guid.Parse(newAgentId)).Result;
            Assert.IsNotNull(newAgentInDb);
            Assert.That(newAgentInDb.UserId, Is.EqualTo(Agent.UserId));
            Assert.That(newAgentInDb.PhoneNumber, Is.EqualTo(Agent.PhoneNumber));


            
        }


        
    }
}