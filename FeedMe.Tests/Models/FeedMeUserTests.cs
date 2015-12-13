using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeUserTests
    {
        [TestMethod]
        public void FeedMeUserEnsureICanCreateAnInstance()
        {
            FeedMeUser a_user = new FeedMeUser();
            Assert.IsNotNull(a_user);

        }
        [TestMethod]
        public void FeedMeUserEnsureUserHasAllProperties()
        {
            FeedMeUser a_user = new FeedMeUser();

            a_user.FirstName = "Betty";
            a_user.LastName = "Crocker";

            
            Assert.AreEqual("Betty", a_user.FirstName);
            Assert.AreEqual("Crocker", a_user.LastName);
        }


    }
}
