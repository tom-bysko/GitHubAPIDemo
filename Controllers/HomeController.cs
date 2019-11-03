using System.Web.Mvc;
using Octokit;
using GitHubWebApp.Models;

namespace GitHubWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GitResults()
        {
            var owner = "octokit";
            var reponame = "octokit.net";
            GitModel gitModel = new GitModel();

            gitModel.client = new GitHubClient(new ProductHeaderValue("octokit.samples"));
            gitModel.repository = gitModel.client.Repository.Get(owner, reponame);
            ViewBag.Message = gitModel;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}