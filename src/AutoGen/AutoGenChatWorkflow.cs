using AutoGen.Core;
using Azure.AI.OpenAI;
using AutoGenMauiPlayground.AutoGen.Agents;
using AutoGenMauiPlayground.Helpers;

namespace AutoGenMauiPlayground.AutoGen
{
    public static class AutoGenChatWorkflow
    {
        public static async Task<IMessage?> ExecuteAsync(string prompt)
        {
            // Use Azure OpenAI
            string model;
            AzureOpenAIClient client;
            AzureOpenAIHelper.GetAutoGenConnectionToLLM(out model, out client);

            // Agent creation
            var specCreatorAgent = SpecCreatorAgent.CreateAgent();
            var diagramCreatorAgent = DiagramCreatorAgent.CreateAgent();
            var infoFormatterAgent = InfoFormatterAgent.CreateAgent();
            var codeCreatorAgent = CodeCreatorAgent.CreateAgent();

            // Middleware creation
            var middleware = new NestedChatMauiDevTeamMiddleware(
                specCreatorAgent,
                diagramCreatorAgent,
                infoFormatterAgent,
                codeCreatorAgent);

            var reviewerAgent = ReviewerAgent.CreateAgent();

            // Register the Middleware agent and setup message printing
            var middlewareAgent = reviewerAgent
                .RegisterMiddleware(middleware)
                .RegisterPrintMessage();

            var message = new TextMessage(Role.User, $"The code to review is: {prompt}");
            IMessage reply = await middlewareAgent.GenerateReplyAsync([message]);

            return reply;
        }
    }

    public class NestedChatMauiDevTeamMiddleware : IMiddleware
    {
        readonly IAgent SpecCreatorAgent;
        readonly IAgent DiagramCreatorAgent;
        readonly IAgent InfoFormatterAgent;
        readonly IAgent CodeCreatorAgent;

        public NestedChatMauiDevTeamMiddleware(
            IAgent specCreatorAgent,
            IAgent diagramCreatorAgent,
            IAgent infoFormatterAgent,
            IAgent codeCreatorAgent)
        {
            SpecCreatorAgent = specCreatorAgent;
            DiagramCreatorAgent = diagramCreatorAgent;
            InfoFormatterAgent = infoFormatterAgent;
            CodeCreatorAgent = codeCreatorAgent;
        }

        public string? Name => nameof(NestedChatMauiDevTeamMiddleware);

        public async Task<IMessage> InvokeAsync(
            MiddlewareContext context,
            IAgent agent,
            CancellationToken cancellationToken = default)
        {
            var messageToReview = context.Messages.Last();
            var reviewPrompt = $"""
            Review the following Application creation request:
            {messageToReview.GetContent()}
            """;

            // Collection to hold all messages from agents
            var allMessages = new List<IMessage>();

            var specCreatorTask = agent.SendAsync(
                receiver: SpecCreatorAgent,
                message: reviewPrompt,
                maxRound: 1)
                .ToListAsync()
                .AsTask();

            var diagramCreatorTask = agent.SendAsync(
                receiver: DiagramCreatorAgent,
                message: reviewPrompt,
                maxRound: 1)
                .ToListAsync()
                .AsTask();

            await Task.WhenAll(
                specCreatorTask,
                diagramCreatorTask);

            var specCreatorMessages = await specCreatorTask;
            allMessages.AddRange(specCreatorMessages);

            var designerMessages = await diagramCreatorTask;
            allMessages.AddRange(designerMessages);

            // Combine the information from all agents
            var allInfo = specCreatorMessages
                .Concat(designerMessages);

            var infoFormatterMessages = await agent.SendAsync(
                receiver: InfoFormatterAgent,
                message: "Aggregate the information from all agents to format the result.",
                chatHistory: allInfo,
                maxRound: 1)
                .ToListAsync();

            allMessages.AddRange(infoFormatterMessages);

            var codeCreatorMessages = await agent.SendAsync(
                receiver: CodeCreatorAgent,
                message: "Generate the code.",
                chatHistory: infoFormatterMessages,
                maxRound: 1)
                .ToListAsync();

            allMessages.AddRange(infoFormatterMessages);

            var result = codeCreatorMessages.Last();
            result.From = agent.Name;

            return result;
        }
    }
}
