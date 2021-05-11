using BotGitHubApi.Business;
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
        private IRepoBusiness _repoBusiness;

        public RepositoryController(ILogger<RepositoryController> logger, IRepoBusiness repoBusiness)
        {
            _logger = logger;
            _repoBusiness = repoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repoBusiness.FindRepos());
        }
    }
}
