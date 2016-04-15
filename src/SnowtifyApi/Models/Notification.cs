using System;
using System.Collections.Generic;

namespace SnowtifyApi.Models
{
    public class Notification
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string LastMessage { get; set; }

        public string Notifier { get; set; }

        public string ImageUrl { get; set; }

        public string SecretKey { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<Follower> Followers { get; set; }
    }
}