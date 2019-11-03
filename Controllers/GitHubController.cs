using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Octokit;
using GitHubWebApp.Models;

namespace GitHubWebApp.Controllers
{
    public class GitHubController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var owner = "octokit";
            var reponame = "octokit.net";
            GitModel gitModel = new GitModel();

            gitModel.client = new GitHubClient(new ProductHeaderValue("octokit.samples"));
            gitModel.repository = gitModel.client.Repository.Get(owner, reponame);

            return new string[] {
                gitModel.repository.Result.Owner.ToString(),
                gitModel.repository.Result.FullName.ToString(),
                gitModel.repository.Result.HtmlUrl.ToString(),
                gitModel.repository.Result.StargazersCount.ToString(),
                gitModel.repository.Result.ForksCount.ToString()
            };
        }

        // GET api/<controller>/<selection>
        public string Get(string id)
        {
            var owner = "octokit";
            var reponame = "octokit.net";
            GitModel gitModel = new GitModel();

            gitModel.client = new GitHubClient(new ProductHeaderValue("octokit.samples"));
            gitModel.repository = gitModel.client.Repository.Get(owner, reponame);
            Dictionary<string, string> apiInfo = new Dictionary<string, string>
            {
                { "owner", gitModel.repository.Result.Owner.ToString() },
                { "fullname",  gitModel.repository.Result.FullName.ToString() },
                { "htmlurl", gitModel.repository.Result.HtmlUrl.ToString() },
                { "watchers", gitModel.repository.Result.StargazersCount.ToString() },
                { "forks", gitModel.repository.Result.ForksCount.ToString() }

            };
            return apiInfo[id];
            
        }
    }
}