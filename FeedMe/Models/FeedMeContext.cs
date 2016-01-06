using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FeedMe.Models
{
    public class FeedMeContext : DbContext
    {
        public virtual DbSet<FeedMeRecipe> Recipes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
    }
}