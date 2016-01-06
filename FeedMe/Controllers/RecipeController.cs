using FeedMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace FeedMe.Controllers
{
    public class RecipeController : Controller
    {

        public FeedMeRepository Repo { get; set; }

        public RecipeController() : base()
        {
            Repo = new FeedMeRepository();
        }

        //public ActionResult Admin()
        //{
        //    List<RecipeUser> all_users = Repo.GetAllUsers();
        //    return View(all_users);
        //}


        // GET: FeedMe
        [Authorize]
        public ActionResult Index()
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            FeedMeUser me = null;
            try
            {
                me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();
            }
            catch (Exception)
            {
                bool successful = Repo.AddNewUser(real_user);
            }

            List<Recipe> recipe_list = Repo.GetUserRecipes(me);
            return View(recipe_list);
         }




        // GET: FeedMe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedMe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedMe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedMe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeedMe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedMe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedMe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
