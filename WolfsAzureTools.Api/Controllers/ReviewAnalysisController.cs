using Microsoft.AspNetCore.Mvc;
using WolfsAzureAItools.Api.Models;
using WolfsAzureAItools.Api.Services;

namespace WolfsAzureAItools.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewAnalysisController : ControllerBase
{
    private readonly IReviewAnalyzer _reviewAnalyzer;

    public ReviewAnalysisController(IReviewAnalyzer reviewAnalyzer)
    {
        _reviewAnalyzer = reviewAnalyzer;
    }

    [HttpPost]
    public async Task<ActionResult<ReviewAnalysisResponse>> Analyze(
        ReviewAnalysisRequest request)
    {
        var result = await _reviewAnalyzer.AnalyzeAsync(request);

        return Ok(result);
    }
}