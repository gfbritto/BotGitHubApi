using BotGitHubApi.Models;
using System.Collections.Generic;

namespace BotGitHubApi.Business
{
    public interface IRepoBusiness
    {
        List<Repo> FindRepos(string org, int per_page, string sortDirection, string language);
        Repo FindRepoByPosition(string org, int position, string sortDirection, string language);
    }
}
