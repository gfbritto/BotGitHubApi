using BotGitHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BotGitHubApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class RepositoryController : ControllerBase
    {

        private readonly ILogger<RepositoryController> _logger;

        public RepositoryController(ILogger<RepositoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repository.GetGitHubRepositories());
        }
    }
}
