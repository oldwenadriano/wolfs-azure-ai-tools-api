using System.Text;

namespace WolfsAzureAItools.Api.Services;

public class KnowledgeContextService
{
    private readonly List<string> _sections = new();

    public KnowledgeContextService()
    {
        var dataPath = Path.Combine(
            AppContext.BaseDirectory,
            "Data");

        var markdownFiles = Directory.GetFiles(dataPath, "*.md");

        foreach (var file in markdownFiles)
        {
            var content = File.ReadAllText(file);

            var splitSections = content.Split(
                "\n---\n",
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var section in splitSections)
            {
                if (!string.IsNullOrWhiteSpace(section))
                {
                    _sections.Add(section.Trim());
                }
            }
        }
    }

    public string GetRelevantContext(string userMessage)
    {
        var keywords = userMessage
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var matchingSections = _sections
        .Where(section =>
            keywords.Any(keyword =>
                section.ToLower().Contains(keyword)))
        .Take(10)
        .ToList();

            if (!matchingSections.Any())
            {
                matchingSections = _sections.Take(10).ToList();
            }

            return string.Join(
                "\n\n---\n\n",
                matchingSections);
    }
}