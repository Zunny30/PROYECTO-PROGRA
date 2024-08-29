using System.Text.Json.Serialization;

namespace PROYECTO_PROGRA.Pages
{
    public class GitHubRepository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        public List<string> Languages { get; set; } = new List<string>();
    }
}
