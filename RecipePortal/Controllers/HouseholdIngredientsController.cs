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
    public class HouseholdIngredientsController : Controller
    {
        private RecipePortalDataContext db = new RecipePortalDataContext();

        // GET: HouseholdIngredients
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: HouseholdIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredient householdIngredient = db.Ingredients.Find(id);
            if (householdIngredient == null)
            {
                return HttpNotFound();
            }
            return View(householdIngredient);
        }

        // GET: HouseholdIngredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseholdIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdIngredientID,HouseholdIngredientName")] HouseholdIngredient householdIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(householdIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(householdIngredient);
        }

        // GET: HouseholdIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredient householdIngredient = db.Ingredients.Find(id);
            if (householdIngredient == null)
            {
                return HttpNotFound();
            }
            return View(householdIngredient);
        }

        // POST: HouseholdIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdIngredientID,HouseholdIngredientName")] HouseholdIngredient householdIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(householdIngredient);
        }

        // GET: HouseholdIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdIngredient householdIngredient = db.Ingredients.Find(id);
            if (householdIngredient == null)
            {
                return HttpNotFound();
            }
            return View(householdIngredient);
        }

        // POST: HouseholdIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdIngredient householdIngredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(householdIngredient);
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
