namespace FeedMe.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FeedMe.Models.FeedMeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FeedMeContext context)
        {
            context.Recipes.AddOrUpdate(x => x.RecipeId,
            new Recipe()
                {
                RecipeId = 1,
                Image = "https://google.com",
                Yield = 4,
                Summary = "A light meal great for entertaining.",
                DateSaved = DateTime.Now,
                Title = "Chicken Cacciatore",
                DietLabels = "high-protein",
                HealthLabels = "gluten-free",
                URL = "http://www.myrecipes.com/recipe/chicken-cacciatore"
                }
            );
        


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
