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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Repo>)),]
        public IActionResult Get()
        {
            return Ok(_repoBusiness.FindRepos());
        }
    }
}
