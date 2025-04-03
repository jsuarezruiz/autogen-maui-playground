using AutoGen.Core;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen.Agents
{
    public static class DiagramCreatorAgent
    {
        public static MiddlewareStreamingAgent<OpenAIChatAgent> CreateAgent()
        {
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            var diagramCreatorAgent = new OpenAIChatAgent(
               chatClient: client.GetChatClient(model),
               name: "DiagramCreator",
               systemMessage: $"""
                You are specialized in interpreting detailed specifications for .NET MAUI applications and transforming them into 
                a mermaid markdown diagram. Produce a diagram with the Application navigation definition.
                """)
               .RegisterMessageConnector()
               .RegisterPrintMessage();

            return diagramCreatorAgent;
        }
    }
}