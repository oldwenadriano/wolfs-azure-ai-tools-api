namespace WolfsAzureAItools.Api.Models;

public class ReviewAnalysisResponse
{
    public string Sentiment { get; set; } = string.Empty;

    public double PositiveConfidence { get; set; }

    public double NeutralConfidence { get; set; }

    public double NegativeConfidence { get; set; }

    public string DetectedLanguage { get; set; } = string.Empty;

    public List<string> KeyPhrases { get; set; } = new();
}