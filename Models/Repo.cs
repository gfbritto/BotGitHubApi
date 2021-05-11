using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BotGitHubApi.Models
{
    public class Repo
    {
        public string full_name { get; set; }
        public string node_id { get; set; }
        //public string description { get; set; }
    }
}
