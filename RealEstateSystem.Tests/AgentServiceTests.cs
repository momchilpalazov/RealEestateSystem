using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystem.Tests.UnitTests;
using RealEstateSystem.Services.Data;
using RealEstateSystem.Tests.Mocks;


namespace RealEstateSystem.Tests
{
    [TestFixture]
    public class AgentServiceTests: UnitTestsBase
    {
        private IAgentInterface agentService; 


        [SetUp]
        public void Setup()
        {
            db = DatabaseMock.Instance;
            agentService = new AgentService(db);
        }

        

        [Test]
        public async Task GetAgentId_ShouldReturnAgentId()
        {


            var resultId = await agentService.GetAgentId(Agent.Id);


            Assert.That(resultId, Is.EqualTo(Agent.Id.ToString()));


        }


        
    }
}