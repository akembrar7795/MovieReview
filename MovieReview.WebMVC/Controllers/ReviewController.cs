using Microsoft.AspNet.Identity;
using MovieReview.Models;
using MovieReview.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReview.WebMVC.Controllers
{
    public class ReviewController : Controller
    {
        [Authorize]
        public ActionResult Create(int id)
        {
            var model = new ReviewCreate
            {
                MovieID = id,
                OwnerID = Guid.Parse(User.Identity.GetUserId())
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId, review.MovieID);

            if (service.CreateReview(review))
            {
                TempData["SaveResult"] = "Your review was created.";
                return RedirectToAction("Details", "Movie", new { id = review.MovieID });
            }

            ModelState.AddModelError("", "Review could not be created");
            return View(review);
        }

    }
}