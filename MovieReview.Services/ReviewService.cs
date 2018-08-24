using MovieReview.Contracts;
using MovieReview.Data;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Guid _userId;
        private readonly int _movieID;

        public ReviewService()
        {

        }
         public ReviewService (Guid userId)
        {
            _userId = userId;
        }

        public ReviewService(Guid userId, int MovieID)
        {
            _userId = userId;
            _movieID = MovieID;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
                {
                    OwnerID = _userId,
                    MovieID = _movieID,
                    Reviews = model.ReviewText,
                    CreatedUtc = DateTimeOffset.Now,
                    UserName = "TemporaryPlaceholderName"
                };
            
             using (var ctx = new ApplicationDbContext())
            {
                ctx.MovieReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ReviewDetail GetSingleReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review =
                    ctx
                        .MovieReviews
                        .SingleOrDefault(r => r.ReviewID == reviewId);

                return
                    new ReviewDetail()
                    {
                        OwnerID = review.OwnerID,
                        MovieID = review.MovieID,
                        Review = review.Reviews,
                        ReviewID = review.ReviewID,
                        UserName = review.UserName,
                        CreatedUtc = review.CreatedUtc,
                    };
            }
        }

        public ICollection<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reviews =
                    ctx
                        .MovieReviews
                        .Where(r => r.OwnerID == _userId)
                        .Select(
                            e =>
                                new ReviewListItem()
                                {
                                    ReviewID = e.ReviewID,
                                    OwnerID = e.OwnerID,
                                    Review = e.Reviews,
                                    UserName = "Dude",
                                    CreatedUtc = e.CreatedUtc,
                                }
                        );
                
                 return reviews.ToList();
            }
        }

        public ICollection<ReviewListItem> GetAllReviewByMovieId(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reviews =
                    ctx
                        .MovieReviews
                        .Where(c => c.MovieID == movieId)
                        .Select(
                            e => new ReviewListItem()
                            {
                                ReviewID = e.ReviewID,
                                OwnerID = e.OwnerID,
                                Review = e.Reviews,
                                CreatedUtc = e.CreatedUtc,
                            }
                        );

                var reviewList = reviews.ToList();

                foreach (var review in reviewList)
                {
                    review.UserName = GetNameFromOwnerId(review.OwnerID);
                }

                return reviewList;

            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public int GetReviewCountByMovieId(int MovieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var count =
                    ctx
                        .MovieReviews
                        .Where(r => r.MovieID == MovieId)
                        .Select(e => e);

                return count.ToList().Count();
            }
        }

        private string GetNameFromOwnerId(Guid ownerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var owner =
                    ctx
                        .Users
                        .SingleOrDefault(u => u.Id == ownerId.ToString());

                return owner.UserName;
            }
        }
    }
}
