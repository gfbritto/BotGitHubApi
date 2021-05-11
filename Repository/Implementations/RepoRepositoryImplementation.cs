using BotGitHubApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BotGitHubApi.Repository.Implementations
{
    public class RepoRepositoryImplementation : IRepoRepository
    {
        public List<Repo> FindRepos()
        {
            //Acessa API do github e pega os ultimos 5 repositórios
            string repoUrlName = "takenet";
            int qtdeResultados = 5;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var response = client
                    .GetAsync($"https://api.github.com/orgs/{repoUrlName}/repos?sort=created&per_page={qtdeResultados}&direction=desc").Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var repositories = JsonConvert.DeserializeObject<List<Repo>>(responseBody);
                return repositories;
            }
        }
    }
}
