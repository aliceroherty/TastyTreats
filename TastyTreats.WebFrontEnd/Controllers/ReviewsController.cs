using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TastyTreats.Model.Entities;
using TastyTreats.Service;

namespace TastyTreats.WebFrontEnd.Controllers
{
    public class ReviewsController : Controller
    {
        ReviewService service = new ReviewService();

        // GET: Create
        public ActionResult Create(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(new Review() { RecipeID = id.Value });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reviews", "Create"));
            }
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                review.ReviewDate = DateTime.Now;

                if (service.AddReview(review))
                {
                    return RedirectToAction("Details", "Recipes", new { id = review.RecipeID });
                }

                return View(review);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reviews", "Create"));
            }
        }
    }
}