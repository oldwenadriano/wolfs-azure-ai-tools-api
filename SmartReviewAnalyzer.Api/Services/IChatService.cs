using WolfsAzureAItools.Api.Models;

namespace WolfsAzureAItools.Api.Services;

public interface IChatService
{
    Task<ChatResponse> SendAsync(ChatRequest request, string profileContext);
}