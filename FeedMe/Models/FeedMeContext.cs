using System.Data.Entity;


namespace FeedMe.Models
{
    public class FeedMeContext : DbContext
    {
        public virtual DbSet<FeedMeUser> FeedMeUsers { get; set; }
        //Not sure if the above is a connector between the FeedMeUsere and the RealUser?

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<IngredientLines> Ingredients { get; set; }
        public virtual DbSet<RecipeNote> Note { get; set; }

    }
}