using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_Twitter.Models
{
    public class SimpleTweet
    {
        public string FullText { get; set; }

        public DateTime CreatedAt { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string ImgUrl { get; set; }
    }
}