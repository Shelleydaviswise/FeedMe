using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeNoteTests
    {
        [TestMethod]
        public void FeedMeNotesEnsureICanCreateAnInstance()
        {
            FeedMeNote a_note = new FeedMeNote();
            Assert.IsNotNull(a_note);
        }

        [TestMethod]
        public void FeedMeRecipeEnsureNoteHasAllProperties()
        {
            FeedMeNote a_note = new FeedMeNote();

            DateTime when_saved = DateTime.Now;
            a_note.RecipeId = 1;
            a_note.Content = "Love this one.";
            a_note.DateSaved = when_saved;
            

            Assert.AreEqual(1, a_note.RecipeId);
            Assert.AreEqual("Love this one.", a_note.Content);
            Assert.AreEqual(when_saved, a_note.DateSaved);
            
        }
    }
}
