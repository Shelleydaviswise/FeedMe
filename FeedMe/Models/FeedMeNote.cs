using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class FeedMeNote
    {
        public string Content { get; set; }
        public DateTime DateSaved { get; set; }
        public int RecipeId { get; set; }
    }
}