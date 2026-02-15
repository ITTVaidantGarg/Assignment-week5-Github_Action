using DotNetEnv;
using ReqresApiAutomation.Clients;

namespace ReqresApiAutomation.Base
{
    public class TestBase
    {
        protected  ReqresClient client;
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Env.Load();
        }

        [SetUp]
        public void Setup()
        {
            client = new ReqresClient();
        }

    }
}