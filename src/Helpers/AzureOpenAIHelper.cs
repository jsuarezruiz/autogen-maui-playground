using Azure;
using Azure.AI.OpenAI;

namespace AutoGenMauiPlayground.Helpers
{
    public static class AzureOpenAIHelper
    {
        public static void GetAutoGenConnectionToLLM(
            out string model,
            out AzureOpenAIClient client)
        {
            var key = EnvironmentHelper.ApiKey;
            var endpoint = EnvironmentHelper.Endpoint;
            model = EnvironmentHelper.DeploymentName; // Example: "gpt-4o";

            client = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
        }
    }
}
