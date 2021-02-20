using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using RecipePortal.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Web.Script.Serialization;


namespace RecipePortal.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes

        private JavaScriptSerializer jss = new JavaScriptSerializer();
        private static readonly HttpClient client;

        public object SelectedRecipe { get; private set; }

        static RecipesController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            client = new HttpClient(handler);
            //change this to match your own local port number
            client.BaseAddress = new Uri("https://localhost:44326/api/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));


            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }



        // GET: Recipe/List
        public ActionResult List()
        {
            string url = "RecipesData/GetRecipes";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<RecipeDto> SelectedRecipes = response.Content.ReadAsAsync<IEnumerable<RecipeDto>>().Result;
                return View(SelectedRecipes);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            ShowRecipe ViewModel = new ShowRecipe();
            string url = "Recipedata/findRecipe/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into Recipe data transfer object
                RecipeDto SelectedRecipe = response.Content.ReadAsAsync<RecipeDto>().Result;
                ViewModel.Recipe = SelectedRecipe;


                //url = "recipedata/findcuisineforrecipe/" + id;
                //response = client.GetAsync(url).Result;
                //CuisineDto SelectedCuisine = response.Content.ReadAsAsync<CuisineDto>().Result;
                //ViewModel.Cuisine = SelectedCuisine;

                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
           
                UpdateRecipe ViewModel = new UpdateRecipe();
                string url = "recipedata/getrecipe";
                HttpResponseMessage response = client.GetAsync(url).Result;
                IEnumerable<CuisineDto> PotentialCuisines = response.Content.ReadAsAsync<IEnumerable<CuisineDto>>().Result;
                ViewModel.allcuisines = PotentialCuisines;

                return View(ViewModel);
                // TODO: Add insert logic here
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipes/Edit/5
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

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipes/Delete/5
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

    internal class RecipeDto
    {
    }
}
