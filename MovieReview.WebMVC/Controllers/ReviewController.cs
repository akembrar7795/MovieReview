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
    [Authorize]
    public class ReviewController : Controller
    {
        
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

        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetSingleReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewID = detail.ReviewID,
                    Review = detail.Review,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReviewService();

            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your review was updated.";
                return RedirectToAction("Index", "Movie");
            }

            ModelState.AddModelError("", "Your review could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();

            var model = svc.GetSingleReviewById(id);
            
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "Your review was deleted";

            return RedirectToAction("Index", "Movie");
        }

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }

    }
}