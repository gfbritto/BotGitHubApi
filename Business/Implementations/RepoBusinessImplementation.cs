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

        public List<Repo> FindRepos(string org, int per_page, string sortDirection, string language)
        {
            var repositories = _repository.FindRepos(org);
            if (repositories != null)
            {
                if (!string.IsNullOrWhiteSpace(language))
                {
                    //Remove null languages
                    repositories = repositories.Where(l => l.language != null).ToList();
                    repositories = repositories.Where(x => x.language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                //filter by number of result
                if (per_page != 0)
                {
                    repositories = repositories.Take(per_page).ToList();
                }
                //asc or desc
                if (!string.IsNullOrWhiteSpace(sortDirection))
                {
                    if (sortDirection == "desc")
                    {
                        repositories = repositories.OrderByDescending(o => o.created_at).ToList();
                    }
                    else
                    {
                        repositories = repositories.OrderBy(o => o.created_at).ToList();
                    }
                }
            }
            return repositories;
        }

        public Repo FindRepoByPosition(string org, int position, string sortDirection, string language)
        {
            var repos = FindRepos(org, 0, "", language);
            if (repos ==null)
            {
                return null;
               
            }
            var repo = repos[position];

            return repo;
        }
    }
}
