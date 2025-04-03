#nullable disable
namespace AutoGenMauiPlayground.Helpers
{
    public static class EnvironmentHelper
    {
        public static string ApiKey => Environment.GetEnvironmentVariable("AzureOpenAI_ApiKey");
        public static string DeploymentName => Environment.GetEnvironmentVariable("AzureOpenAI_Model");
        public static string Endpoint => Environment.GetEnvironmentVariable("AzureOpenAI_Endpoint");
    }
}