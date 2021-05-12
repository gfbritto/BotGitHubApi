using BotGitHubApi.Models;
using BotGitHubApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotGitHubApi.Business.Implementations
{
    public class RepoBusinessImplementation : IRepoBusiness
    {
        private readonly IRepoRepository _repository;

        public RepoBusinessImplementation(IRepoRepository repoRepository)
        {
            _repository = repoRepository;
        }
        public List<Repo> FindRepos()
        {
            var repositories = _repository.FindRepos();
            //filter by c# language, top five and order by creation date 
            repositories = repositories.Where(x => x.language == "C#").OrderBy(o => o.created_at).Take(5).ToList();
            return repositories;
        }
    }
}
