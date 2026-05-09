using WolfsAzureAItools.Api.Models;

namespace WolfsAzureAItools.Api.Services;

public class MockReviewAnalyzer : IReviewAnalyzer
{
    public Task<ReviewAnalysisResponse> AnalyzeAsync(ReviewAnalysisRequest request)
    {
        var response = new ReviewAnalysisResponse
        {
            Sentiment = "Positive",
            PositiveConfidence = 0.92,
            NeutralConfidence = 0.06,
            NegativeConfidence = 0.02,
            DetectedLanguage = "English",
            KeyPhrases = new List<string>
            {
                "great service",
                "fast delivery",
                "quality product"
            }
        };

        return Task.FromResult(response);
    }
}