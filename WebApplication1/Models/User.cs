using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Company { get; set; }
        public int Followers { get; set; }
        public int PublicRepos { get; set; }
        public int FollowersPerRepo 
        {
            get {
                if (Followers > 0)
                    return Followers / PublicRepos;
                else
                    return 0;
            }
        }
    }
}
