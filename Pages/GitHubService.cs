using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace PROYECTO_PROGRA.Pages
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubRepository>> GetRepositoriesAsync(string username)
        {
            var repositories = await _httpClient.GetFromJsonAsync<List<GitHubRepository>>(
                $"https://api.github.com/users/{username}/repos");

            foreach (var repo in repositories)
            {
                var languagesUrl = $"https://api.github.com/repos/{username}/{repo.Name}/languages";
                var languagesResponse = await _httpClient.GetAsync(languagesUrl);

                if (languagesResponse.IsSuccessStatusCode)
                {
                    var languagesJson = await languagesResponse.Content.ReadAsStringAsync();
                    var languagesDict = JsonSerializer.Deserialize<Dictionary<string, int>>(languagesJson);

                    if (languagesDict != null)
                    {
                        repo.Languages.AddRange(languagesDict.Keys);
                    }
                }
            }

            return repositories;
        }
    }
}
