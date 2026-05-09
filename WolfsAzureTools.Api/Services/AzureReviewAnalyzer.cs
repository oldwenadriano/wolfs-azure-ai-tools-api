using Azure;
using Azure.AI.TextAnalytics;
using WolfsAzureAItools.Api.Models;

namespace WolfsAzureAItools.Api.Services;

public class AzureReviewAnalyzer : IReviewAnalyzer
{
    private readonly TextAnalyticsClient _client;

    public AzureReviewAnalyzer(IConfiguration configuration)
    {
        var endpoint = configuration["AzureLanguage:Endpoint"];
        var apiKey = configuration["AzureLanguage:ApiKey"];

        _client = new TextAnalyticsClient(
            new Uri(endpoint!),
            new AzureKeyCredential(apiKey!));
    }

    public async Task<ReviewAnalysisResponse> AnalyzeAsync(ReviewAnalysisRequest request)
    {
        var sentimentResult = await _client.AnalyzeSentimentAsync(request.Text);
        var keyPhraseResult = await _client.ExtractKeyPhrasesAsync(request.Text);
        var languageResult = await _client.DetectLanguageAsync(request.Text);

        return new ReviewAnalysisResponse
        {
            Sentiment = sentimentResult.Value.Sentiment.ToString(),
            PositiveConfidence = sentimentResult.Value.ConfidenceScores.Positive,
            NeutralConfidence = sentimentResult.Value.ConfidenceScores.Neutral,
            NegativeConfidence = sentimentResult.Value.ConfidenceScores.Negative,
            DetectedLanguage = languageResult.Value.Name,
            KeyPhrases = keyPhraseResult.Value.ToList()
        };
    }
}