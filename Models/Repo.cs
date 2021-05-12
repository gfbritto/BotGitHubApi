using System;

namespace BotGitHubApi.Models
{
    public class Repo
    {
        public string name { get; set; }

        public string full_name { get; set; }

        public string description { get; set; }

        public string language { get; set; }

        public DateTime created_at { get; set; }

        public Owner owner { get; set; }


    }
}
