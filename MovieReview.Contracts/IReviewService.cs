using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Contracts
{
    public interface IReviewService
    {
        bool CreateReview(ReviewCreate model);
        ICollection<ReviewListItem> GetReviews();
        ICollection<ReviewListItem> GetAllReviewByMovieId(int movieId);
        ReviewDetail GetSingleReviewById(int reviewId);
        bool UpdateReview(ReviewEdit model);
        bool DeleteReview(int reviewId);
    }
}
