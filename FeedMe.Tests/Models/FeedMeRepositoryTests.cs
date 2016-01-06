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
        private Mock<DbSet<RecipeIngredients>> mock_ingredients_set;
        private FeedMeRepository repo;

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

        private void ConnectMocksToDataStore(IEnumerable<RecipeIngredients> data_store)
        {
            var data_source = data_store.AsQueryable<RecipeIngredients>();
            // HINT HINT: var data_source = (data_store as IEnumerable<Ingredients>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_ingredients_set.As<IQueryable<RecipeIngredients>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_ingredients_set.As<IQueryable<RecipeIngredients>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_ingredients_set.As<IQueryable<RecipeIngredients>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_ingredients_set.As<IQueryable<RecipeIngredients>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the Ingredientss property getter
            mock_context.Setup(a => a.Ingredients).Returns(mock_ingredients_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<FeedMeContext>();
            mock_set = new Mock<DbSet<Recipe>>();
            mock_ingredients_set = new Mock<DbSet<RecipeIngredients>>();
            repo = new FeedMeRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            mock_ingredients_set = null;
            repo = null;
        }

        [TestMethod]
        public void FeedMeContextEnsureICanCreateAnInstance()
        {
            FeedMeContext context = mock_context.Object;
            Assert.IsNotNull(context);

        }

        [TestMethod]
        public void FeedMeRepositoryEnsureICanCreateAnInstance()
        {
            //FeedMeRepository repo = new FeedMeRepository();
            Assert.IsNotNull(repo);
         }

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

        [TestMethod]
        public void FeedMeRepositoryEnsureIHaveAContext()
        {
            //Arrange
            //Act
            var actual = repo.Context;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(FeedMeContext));
        }

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


        [TestMethod]
        public void FeedMeRepositoryEnsureICanSearchByRecipeHealthLabel()
        {
            var expected = new List<Recipe>
            {
                new Recipe {Title = "Chicken Cacciatore", HealthLabels = "vegan"},
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

        [TestMethod]
        public void FeedMeRepositoryEnsureICanCreateANote()
        {
            //Arrange
          //  DateTime base_time = new DateTime.Now;
            List<RecipeNote> expected_notes = new List<RecipeNote>();

        }

    }
}
