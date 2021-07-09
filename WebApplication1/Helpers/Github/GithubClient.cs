using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication1.Helpers.Github
{
    public class GithubClient
    {
        private const string BaseUrl = "https://api.github.com";

        public async Task<GithubUser> GetUserDetail(string username) 
        {
            var req_string = $"{BaseUrl}/users/{username}";
            var req = (HttpWebRequest)WebRequest.Create(req_string);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.UserAgent = "request";

            try
            {
                using (HttpWebResponse response = await req.GetResponseAsync() as HttpWebResponse)
                {
                    if (response == null) return null;

                    Encoding encoding = Encoding.GetEncoding("utf-8");

                    System.IO.StreamReader reader =
                        new System.IO.StreamReader(
                            response.GetResponseStream() ?? throw new InvalidOperationException(), encoding);
                    var ApiStatus = reader.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<GithubUser>(ApiStatus);
                    return data;
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
    }
}
