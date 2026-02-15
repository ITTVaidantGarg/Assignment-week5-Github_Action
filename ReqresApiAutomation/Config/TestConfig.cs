namespace ReqresApiAutomation.Config
{
    public static class TestConfig
    {
        public static string BaseUrl =>
            Environment.GetEnvironmentVariable("BASE_URL")
            ?? throw new Exception("BASE_URL not set");

        public static string ApiKey =>
            Environment.GetEnvironmentVariable("API_KEY")
            ?? throw new Exception("API_KEY not set");
    }
}
