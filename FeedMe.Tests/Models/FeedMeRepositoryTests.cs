using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Data.Entity;
using System;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeRepositoryTests
    {
        private Mock<FeedMeContext> mock_context;
        private Mock<DbSet<Recipe>> mock_set;
        private Mock<DbSet<IngredientLines>> mock_ingredients_set;
        private Mock<DbSet<RecipeNote>> mock_notes_set;
        private FeedMeRepository repo;
        private ApplicationUser testUser1;
        private ApplicationUser testUser2;

        private void ConnectMocksToDataStore(IEnumerable<Recipe> data_store)
        {
            var data_source = data_store.AsQueryable<Recipe>();
            // HINT HINT: var data_source = (data_store as IEnumerable<Recipe>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_set.As<IQueryable<Recipe>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<Recipe>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<Recipe>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<Recipe>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the Recipes property getter
            mock_context.Setup(a => a.Recipes).Returns(mock_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<IngredientLines> data_store)
        {
            var data_source = data_store.AsQueryable<IngredientLines>();
            // HINT HINT: var data_source = (data_store as IEnumerable<Ingredients>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_ingredients_set.As<IQueryable<IngredientLines>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_ingredients_set.As<IQueryable<IngredientLines>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_ingredients_set.As<IQueryable<IngredientLines>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_ingredients_set.As<IQueryable<IngredientLines>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the Ingredientss property getter
            mock_context.Setup(a => a.Ingredients).Returns(mock_ingredients_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<RecipeNote> data_store)
        {
            var data_source = data_store.AsQueryable<RecipeNote>();
            // HINT HINT: var data_source = (data_store as IEnumerable<Ingredients>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_notes_set.As<IQueryable<RecipeNote>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_notes_set.As<IQueryable<RecipeNote>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_notes_set.As<IQueryable<RecipeNote>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_notes_set.As<IQueryable<RecipeNote>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the Ingredientss property getter
            mock_context.Setup(a => a.Note).Returns(mock_notes_set.Object);
        }


        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<FeedMeContext>();
            mock_set = new Mock<DbSet<Recipe>>();
            mock_ingredients_set = new Mock<DbSet<IngredientLines>>();
            repo = new FeedMeRepository(mock_context.Object);
           // testUser1 = new ApplicationUser { Email = "testUser1@generic.com", Id = "user1" };
          //  testUser2 = new ApplicationUser { Email = "testUser2@generic.com", Id = "user1" };


        }
        //Test CleanUp
        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            mock_ingredients_set = null;
            repo = null;
        }


        //Context Creation Instance Test
        [TestMethod]
        public void FeedMeContextEnsureICanCreateAnInstance()
        {
            FeedMeContext context = mock_context.Object;
            Assert.IsNotNull(context);

        }

        //Have a Context Test
        [TestMethod]
        public void FeedMeRepositoryEnsureIHaveAContext()
        {
            //Arrange
            //Act
            var actual = repo.Context;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(FeedMeContext));
        }



        //Repository Creation Instance Test
        [TestMethod]
        public void FeedMeRepositoryEnsureICanCreateAnInstance()
        {
            //FeedMeRepository repo = new FeedMeRepository();
            Assert.IsNotNull(repo);
         }

        //Create Recipes Test
        [TestMethod]
        public void FeedMeRepositoryEnsureICanCreateARecipe()
        {
            //Arrange
            List<Recipe> expected_recipes = new List<Recipe>();
       
            List<RecipeNote> expected_notes = new List<RecipeNote>();
        }


        //Get All Recipes Test
        [TestMethod]
        public void FeedMeRepositoryEnsureICanGetAllRecipes()
        {
            var expected = new List<Recipe>
            {
                new Recipe {Title = "Chicken Cacciatore" },
                new Recipe {Title = "Beef Stew" }
            };
            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
        
            //Act
            var actual = repo.GetAllRecipes();

            Assert.AreEqual("Chicken Cacciatore", actual.First().Title);
            CollectionAssert.AreEqual(expected, actual);
        }

   
      

        //Search By Diet Label
        [TestMethod]
        public void FeedMeRepositoryEnsureICanSearchByRecipeDietLabel()
        {
            var expected = new List<Recipe>
            {
                new Recipe {Title = "Chicken Cacciatore", DietLabels = "low-fat"},
                new Recipe {Title = "Chicken with Mushrooms", DietLabels = "high-protein" },
                new Recipe {Title = "Beef Stew", DietLabels = "low-fat" },
                new Recipe {Title = "Chicken Salad", DietLabels= "low-sodium" }
            };

            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);

            string search_term = "low";

            List<Recipe> expected_recipes = new List<Recipe>
            {
                new Recipe {Title = "Beef Stew", DietLabels = "low-fat" },
                new Recipe {Title = "Chicken Cacciatore", DietLabels = "low-fat"}
            };

            List<Recipe> actual_recipes = repo.SearchByDietLabels(search_term);

            Assert.AreEqual(expected_recipes[0].Title, actual_recipes[0].Title);
            Assert.AreEqual(expected_recipes[1].Title, actual_recipes[1].Title);
        }

        //Search by Health Label
        [TestMethod]
        public void FeedMeRepositoryEnsureICanSearchByRecipeHealthLabel()
        {
            var expected = new List<Recipe>
            {
                new Recipe {Title = "Chicken Cacciatore", HealthLabels = "low-carb"},
                new Recipe {Title = "Chicken with Mushrooms", HealthLabels = "gluten-free" },
                new Recipe {Title = "Beef Stew", HealthLabels = "paleo" },
                new Recipe {Title = "Chicken Salad", HealthLabels = "gluten-free" }
            };

            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);

            string search_term = "gluten";

            List<Recipe> expected_recipes = new List<Recipe>
            {
                new Recipe {Title = "Chicken Salad", HealthLabels = "gluten-free" },
                new Recipe {Title = "Chicken with Mushrooms", HealthLabels = "gluten-free" }
            };

            List<Recipe> actual_recipes = repo.SearchByHealthLabels(search_term);

            Assert.AreEqual(expected_recipes[0].Title, actual_recipes[0].Title);
            Assert.AreEqual(expected_recipes[1].Title, actual_recipes[1].Title);
        }

        //    //Search by Title
        //[TestMethod]
        //public void FeedMeRepositoryEnsureICanSearchByRecipeTitle()
        //{
        //    var expected = new List<Recipe>
        //    {
        //        new Recipe {Title = "Chicken Cacciatore", HealthLabels = "low-carb"},
        //        new Recipe {Title = "Chicken with Mushrooms", HealthLabels = "gluten-free" },
        //        new Recipe {Title = "Beef Stew", HealthLabels = "paleo" },
        //        new Recipe {Title = "Chicken Salad", HealthLabels = "gluten-free" }
        //    };

        //    mock_set.Object.AddRange(expected);

        //    ConnectMocksToDataStore(expected);

        //    string search_term = "Chicken Salad";

        //    List<Recipe> expected_recipes = new List<Recipe>
        //    {
        //        new Recipe {Title = "Chicken Salad", HealthLabels = "gluten-free" },
        //        new Recipe {Title = "Chicken with Mushrooms", HealthLabels = "gluten-free" }
        //    };

        //    List<Recipe> actual_recipes = repo.SearchByTitle(search_term);

        //    Assert.AreEqual(expected_recipes[0].Title, actual_recipes[0].Title);
        //    Assert.AreEqual(expected_recipes[1].Title, actual_recipes[1].Title);
        //}



        [TestMethod]
        public void FeedMeRepositoryEnsureICanGetAllRecipesForAUser()
        {
            List<FeedMeUser> user_list = new List<FeedMeUser>();
            List<Recipe> recipe_list = new List<Recipe>();

            Recipe sample_recipe = new Recipe();

            sample_recipe.DateSaved = 
            sample_recipe.RecipeId = 1;
            sample_recipe.Title = "Fried Chicken";
            sample_recipe.Image = "www.flickr.com/friedchicken";
            sample_recipe.Ingredients = "chicken, flour, salt";
            sample_recipe.HealthLabels = "Low-Fat";
            sample_recipe.DietLabels = "Gluten-Free";
            sample_recipe.Summary = "Juicy and succulent";
            sample_recipe.URL = "www.allrecipes.com/mamasfriedchicken";
            sample_recipe.Yield = 4;
            

        }
    }
}
