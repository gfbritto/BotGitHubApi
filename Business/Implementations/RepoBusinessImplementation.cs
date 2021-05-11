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
            return _repository.FindRepos();
        }
    }
}
