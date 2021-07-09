using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Helpers.Github;
using System.Linq;

namespace WebApplication1
{
    public class GithubService : IGithubService
    {
        public GithubService() { }
        public async Task<List<User>> RetrieveUsers(List<string> usernames) 
        {
            var result = new List<User>();
            var githubClient = new GithubClient();
            var cleanList = RemoveDuplicate(usernames);
            foreach (var user in cleanList) 
            {
                var response = await githubClient.GetUserDetail(user);
                var item = new User
                {
                    Name = response.name,
                    Login = response.login,
                    Company = response.company,
                    Followers = response.followers,
                    PublicRepos = response.public_repos
                };
                result.Add(item);
            }
            return result.OrderBy(x => x.Name).ToList();
        }

        private List<string> RemoveDuplicate(List<string> usernames) 
        {
            return usernames.Distinct().ToList();
        }
    }
}
