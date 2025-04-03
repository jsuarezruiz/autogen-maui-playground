using AutoGen.Core;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen.Agents
{
    public static class ReviewerAgent
    {
        public static MiddlewareStreamingAgent<OpenAIChatAgent> CreateAgent()
        {
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            var infoFormatterAgent = new OpenAIChatAgent(
               chatClient: client.GetChatClient(model),
               name: "Reviewer",
               systemMessage: $"""
                You are designed to review source code and provide detailed comments. 
                """)
               .RegisterMessageConnector()
               .RegisterPrintMessage();

            return infoFormatterAgent;
        }
    }
}