using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using WolfsAzureAItools.Api.Models;

namespace WolfsAzureAItools.Api.Services;


public class AzureChatService : IChatService
{
    private readonly string _knowledgeContext;

    private readonly ChatClient _chatClient;

    public AzureChatService(IConfiguration configuration)
    {
        var endpoint = configuration["AzureOpenAI:Endpoint"];
        var apiKey = configuration["AzureOpenAI:ApiKey"];
        var deploymentName = configuration["AzureOpenAI:DeploymentName"];
        var path = Path.Combine(AppContext.BaseDirectory, "Data", "personal-profile.md");
        _knowledgeContext = File.ReadAllText(path);

        var azureClient = new AzureOpenAIClient(
            new Uri(endpoint!),
            new AzureKeyCredential(apiKey!));

        _chatClient = azureClient.GetChatClient(deploymentName!);
    }

    public async Task<ChatResponse> SendAsync(ChatRequest request, string knowledgeContext)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(
                                            $"""
                    You are an AI assistant for Oldwen Adriano's professional portfolio.

                    Rules:
                    - Answer clearly and professionally.
                    - Do not invent experience, employers, certifications, or technologies.
                    - If the knowledge context does not contain the answer, say you do not have that information.
                    - Keep answers concise unless the user asks for more detail.

                    Use the following knowledge context when answering questions about Oldwen Adriano's background, skills, and projects:

                    {knowledgeContext}

                    If the answer is not found in the knowledge context, say that you do not have that information.
                    """
            )
        };

        foreach (var item in request.History)
        {
            messages.Add(new UserChatMessage(item));
        }

        messages.Add(new UserChatMessage(request.Message));

        ChatCompletion completion = await _chatClient.CompleteChatAsync(messages);

        return new ChatResponse
        {
            Reply = completion.Content[0].Text
        };
    }
}