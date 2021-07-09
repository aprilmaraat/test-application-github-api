using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using WebApplication1.Helpers.Github;

namespace WebApplication1.Controllers
{
    [Route("api/github")]
    public class GithubController : Controller
    {
        private readonly IGithubService _githubService;
        public GithubController(IGithubService githubService) 
        {
            _githubService = githubService;
        }

        [HttpPost("retrieveUsers")]
        public async Task<IActionResult> RetrieveUsers([FromBody] List<string> usernames)
        {
            var githubClient = new GithubClient();
            var response = await _githubService.RetrieveUsers(usernames);
            return Ok(response);
        }
    }
}
