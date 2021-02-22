using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipePortal.Models;

namespace RecipePortal.Controllers
{
    public class HouseholdIngredientsxRecipesController : Controller
    {
        private RecipePortalDataContext db = new RecipePortalDataContext();

        // GET: HouseholdIngredientsxRecipes
        public ActionResult Index()
        {
            var householdIngredients = db.HouseholdIngredients.Include(h => h.HouseholdIngredient).Include(h => h.Recipe);
            return View(householdIngredients.ToList());
        }

        // GET: HouseholdIngredientsxRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredientsxRecipes householdIngredientsxRecipes = db.HouseholdIngredients.Find(id);
            if (householdIngredientsxRecipes == null)
            {
                return HttpNotFound();
            }
            return View(householdIngredientsxRecipes);
        }

        // GET: HouseholdIngredientsxRecipes/Create
        public ActionResult Create()
        {
            ViewBag.HouseholdIngredientID = new SelectList(db.Ingredients, "HouseholdIngredientID", "HouseholdIngredientName");
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName");
            return View();
        }

        // POST: HouseholdIngredientsxRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,HouseholdIngredientID,HouseholdIngredientsxRecipesID")] HouseholdIngredientsxRecipes householdIngredientsxRecipes)
        {
            if (ModelState.IsValid)
            {
                db.HouseholdIngredients.Add(householdIngredientsxRecipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseholdIngredientID = new SelectList(db.Ingredients, "HouseholdIngredientID", "HouseholdIngredientName", householdIngredientsxRecipes.HouseholdIngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", householdIngredientsxRecipes.RecipeID);
            return View(householdIngredientsxRecipes);
        }

        // GET: HouseholdIngredientsxRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredientsxRecipes householdIngredientsxRecipes = db.HouseholdIngredients.Find(id);
            if (householdIngredientsxRecipes == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdIngredientID = new SelectList(db.Ingredients, "HouseholdIngredientID", "HouseholdIngredientName", householdIngredientsxRecipes.HouseholdIngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", householdIngredientsxRecipes.RecipeID);
            return View(householdIngredientsxRecipes);
        }

        // POST: HouseholdIngredientsxRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,HouseholdIngredientID,HouseholdIngredientsxRecipesID")] HouseholdIngredientsxRecipes householdIngredientsxRecipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdIngredientsxRecipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdIngredientID = new SelectList(db.Ingredients, "HouseholdIngredientID", "HouseholdIngredientName", householdIngredientsxRecipes.HouseholdIngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", householdIngredientsxRecipes.RecipeID);
            return View(householdIngredientsxRecipes);
        }

        // GET: HouseholdIngredientsxRecipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredientsxRecipes householdIngredientsxRecipes = db.HouseholdIngredients.Find(id);
            if (householdIngredientsxRecipes == null)
            {
                return HttpNotFound();
            }
            return View(householdIngredientsxRecipes);
        }

        // POST: HouseholdIngredientsxRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdIngredientsxRecipes householdIngredientsxRecipes = db.HouseholdIngredients.Find(id);
            db.HouseholdIngredients.Remove(householdIngredientsxRecipes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
