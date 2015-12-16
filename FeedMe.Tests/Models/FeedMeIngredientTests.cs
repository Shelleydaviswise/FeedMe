﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;
using System.Collections.Generic;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeIngredientTests
    {
        [TestMethod]
        public void FeedMeIngredientsEnsureICanCreateAnInstance()
        {
            Ingredients the_ingredients = new Ingredients();
            Assert.IsNotNull(the_ingredients);

        }

        [TestMethod]
        public void FeedMeIngredientsEnsureItHasAllTheProperties()
        {
            Ingredients the_ingredients = new Ingredients();

            the_ingredients.Quantity = 2;
            the_ingredients.Measure = "lbs";
            the_ingredients.Weight = 2;
            the_ingredients.Food = "Chicken";

            Assert.AreEqual(2, the_ingredients.Quantity);
            Assert.AreEqual("lbs", the_ingredients.Measure);
            Assert.AreEqual(2, the_ingredients.Weight);
            Assert.AreEqual("Chicken", the_ingredients.Food);
        }

       
    }
}
