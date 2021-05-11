using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BotGitHubApi.Models
{
    public class Repository
    {
        public string full_name { get; set; }
        public string node_id { get; set; }
        //public string description { get; set; }

        public static List<Repository> GetGitHubRepositories()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var response = client.GetAsync("https://api.github.com/orgs/takenet/repos?sort=created&per_page=5&direction=desc").Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var repositories = JsonConvert.DeserializeObject<List<Repository>>(responseBody);
                return repositories;
            }
        }
    }
}
