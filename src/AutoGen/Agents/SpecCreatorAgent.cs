using AutoGen.Core;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen.Agents
{
    public static class SpecCreatorAgent
    {
        public static MiddlewareStreamingAgent<OpenAIChatAgent> CreateAgent()
        {
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            var specCreatorAgent = new OpenAIChatAgent(
               chatClient: client.GetChatClient(model),
               name: "SpecCreator",
               systemMessage: $"""
                You are an assistant capable of transforming high-level definitions into detailed, actionable specifications for 
                the development of .NET MAUI applications. 
                Ensures clarity, completeness, and accuracy of app requirements while aligning with best practices for .NET MAUI.
                Write a markdown document that includes the following sections:
                1. **Introduction**: Overview of the app's purpose and target audience.
                2. **Functional Requirements**: Detailed description of the app's features and functionalities.
                3. **Non-Functional Requirements**: Performance, security, and usability considerations.
                4. **User Interface Requirements**: Design guidelines and user experience considerations.
                5. **Acceptance Criteria**: Conditions that must be met for the app to be considered complete.
                6. **Appendix**: Any additional information or references.
                """)
               .RegisterMessageConnector()
               .RegisterPrintMessage();

            return specCreatorAgent;
        }
    }
}
