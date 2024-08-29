using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
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

            return repositories;
        }
    }
}
