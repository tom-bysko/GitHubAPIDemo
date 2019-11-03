using System.Threading.Tasks;
using Octokit;

namespace GitHubWebApp.Models
{
    public class GitModel
    {
        public GitHubClient client { get; set; }
        public Task<Repository> repository { get; set; }

    }
}