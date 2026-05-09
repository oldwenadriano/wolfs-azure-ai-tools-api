using Microsoft.AspNetCore.Mvc;
using WolfsAzureAItools.Api.Models;
using WolfsAzureAItools.Api.Services;

namespace WolfsAzureAItools.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly KnowledgeContextService _knowledgeContextService;

    public ChatController(
        IChatService chatService,
        KnowledgeContextService knowledgeContextService)
    {
        _chatService = chatService;
        _knowledgeContextService = knowledgeContextService;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Send(ChatRequest request)
    {
        var knowledgeContext = _knowledgeContextService.GetRelevantContext(request.Message);

        var result = await _chatService.SendAsync(request, knowledgeContext);

        return Ok(result);
    }
}