using BotGitHubApi.Models;
using System.Collections.Generic;

namespace BotGitHubApi.Repository
{
    public interface IRepoRepository
    {
        List<Repo> FindRepos();
    }
}
