using BotGitHubApi.Business;
using BotGitHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BotGitHubApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class RepositoryController : ControllerBase
    {

        private readonly ILogger<RepositoryController> _logger;
        private IRepoBusiness _repoBusiness;

        public RepositoryController(ILogger<RepositoryController> logger, IRepoBusiness repoBusiness)
        {
            _logger = logger;
            _repoBusiness = repoBusiness;
        }

        [HttpGet("{org}")]
        [ProducesResponseType(200, Type = typeof(List<Repo>))]
        public IActionResult Get(string org, [FromQuery] int per_page = 10, [FromQuery] string sortDirection = "asc", [FromQuery] string language = "")
        {
            var repos = _repoBusiness.FindRepos(org, per_page, sortDirection, language);
            if (repos == null) return NotFound();

            return Ok(repos);

        }
        [HttpGet("{org}/{position}")]
        [ProducesResponseType(200, Type = typeof(Repo))]
        public IActionResult GetbyOrder(string org, int position, [FromQuery] string sortDirection = "asc", [FromQuery] string language = "")
        {
            var repo = _repoBusiness.FindRepoByPosition(org, position, sortDirection, language);
            if (repo == null) return NotFound();
            return Ok(repo);
        }
    }
}
