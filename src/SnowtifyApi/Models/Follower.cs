using System;

namespace SnowtifyApi.Models
{
    public class Follower
    {
        public string Id { get; set; }

        public string PushId { get; set; }

        public string PushType { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastActivityDate { get; set; }
    }
}