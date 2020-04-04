using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using TastyTreats.Service;
using TastyTreats.WebFrontEnd.ViewModels;
using TastyTreats.Model.Entities;
using TastyTreats.Model.DTO;

namespace TastyTreats.WebFrontEnd.Controllers
{
    public class RecipesController : Controller
    {
        RecipeService service = new RecipeService();

        // GET: Recipes
        public ActionResult Index()
        {
            try
            {
                return View(service.GetRecipes());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Recipes", "Index"));
            }
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Recipe r = service.Get(id.Value);

                if (r == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                RecipeEditVM vm = new RecipeEditVM
                {
                    Recipe = r,
                    Chefs = GetChefs(),
                    RecipeTypes = GetRecipeTypes()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Recipes", "Edit"));
            }
        }
        
        // POST: Edit
        [HttpPost]
        public ActionResult Edit(RecipeEditVM vm)
        {
            try
            {
                if (service.UpdateRecipe(vm.Recipe))
                {
                    return RedirectToAction("Index");
                }

                vm.Chefs = GetChefs();
                vm.RecipeTypes = GetRecipeTypes();

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Recipes", "Edit"));
            }
        }

        // GET: Details
        public ActionResult Details(int? id)
        {
            try {
                if (!id.HasValue)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                RecipeReviewsDTO recipeWithReviews = service.GetRecipeWithReviews(id.Value);

                if (recipeWithReviews == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                RecipeDetailsVM vm = new RecipeDetailsVM()
                {
                    RecipeId = recipeWithReviews.Details.ID,
                    Title = recipeWithReviews.Details.Title,
                    Chef = recipeWithReviews.Details.ChefFullName,
                    Yield = recipeWithReviews.Details.Yield,
                    Archived = recipeWithReviews.Details.Archived,
                    Reviews = recipeWithReviews.Reviews
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Recipes", "Edit"));
            }
        }

        private static List<SelectListItem> GetChefs()
        {
            return new LookupsService().GetChefs()
                .Select(chef => new SelectListItem
                {
                    Value = chef.ID.ToString(),
                    Text = chef.Name
                }).ToList();
        }

        private static List<SelectListItem> GetRecipeTypes()
        {
            return new LookupsService().GetRecipeTypes()
                .Select(type => new SelectListItem
                {
                    Value = type.ID.ToString(),
                    Text = type.Name
                }).ToList();
        }
    }
}