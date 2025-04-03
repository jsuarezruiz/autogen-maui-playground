using AutoGen.Core;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen.Agents
{
    public static class InfoFormatterAgent
    {
        public static MiddlewareStreamingAgent<OpenAIChatAgent> CreateAgent()
        {
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            var infoFormatterAgent = new OpenAIChatAgent(
               chatClient: client.GetChatClient(model),
               name: "InfoFormatter",
               systemMessage: $"""
                You are designed to accept both a detailed .NET MAUI app specification and a navigation diagram, process the information, 
                and generate a consolidated, well-structured, and formatted document. 
                You must ensures alignment between specifications and navigation flow while producing a ready-to-use document for developers.
                """)
               .RegisterMessageConnector()
               .RegisterPrintMessage();

            return infoFormatterAgent;
        }
    }
}