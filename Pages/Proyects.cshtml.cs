using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PROYECTO_PROGRA.Pages
{
    public class ProyectsModel : PageModel
    {
        private readonly GitHubService _gitHubService;

        public ProyectsModel(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public List<GitHubRepository> Repositories { get; set; }

        public async Task OnGetAsync()
        {
            
            Repositories = await _gitHubService.GetRepositoriesAsync("Zunny30");
        }
    }
}
