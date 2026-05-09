using WolfsAzureAItools.Api.Models;

namespace WolfsAzureAItools.Api.Services;

public interface IReviewAnalyzer
{
    Task<ReviewAnalysisResponse> AnalyzeAsync(ReviewAnalysisRequest request);
}