using BotGitHubApi.Models;
using System.Collections.Generic;

namespace BotGitHubApi.Business
{
    public interface IRepoBusiness
    {
        List<Repo> FindRepos();
    }
}
