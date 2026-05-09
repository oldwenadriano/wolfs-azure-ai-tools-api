namespace WolfsAzureAItools.Api.Models;

public class ChatRequest
{
    public string Message { get; set; } = string.Empty;

    public List<string> History { get; set; } = new();
}