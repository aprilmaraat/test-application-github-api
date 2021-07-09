using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IGithubService
    {
        Task<List<User>> RetrieveUsers(List<string> usernames); 
    }
}
