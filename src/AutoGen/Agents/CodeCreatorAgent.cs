using AutoGen.Core;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen.Agents
{
    public static class CodeCreatorAgent
    {
        public static MiddlewareStreamingAgent<OpenAIChatAgent> CreateAgent()
        {
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            var codeCreatorAgent = new OpenAIChatAgent(
               chatClient: client.GetChatClient(model),
               name: "CodeCreator",
               systemMessage: $"""
                You are capable of receiving detailed specifications and accompanying designs for a .NET MAUI application, 
                and generating production-ready code. 
                You must bridges the gap between requirements/designs and development, expediting the .NET MAUI app creation process.
                """)
               .RegisterMessageConnector()
               .RegisterPrintMessage();

            return codeCreatorAgent;
        }
    }
}
