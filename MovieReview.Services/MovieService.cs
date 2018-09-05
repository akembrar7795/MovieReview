using MovieReview.Data;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService() { }

        public MovieService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    OwnerID = _userId,
                    MovieName = model.MovieName,
                    Genre = model.Genre,
                    Director = model.Director,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MovieReviews2.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<MovieListItem> GetMovie()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movies =
                    ctx
                        .MovieReviews2
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieID = e.MovieID,
                                    MovieName = e.MovieName,
                                    Genre = e.Genre,
                                    Director = e.Director,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return movies.ToArray();
            }
        }

        public MovieDetail GetMovieById(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews2
                        .Single(e => e.MovieID == movieId && e.OwnerID == _userId);
                var reviewService = new ReviewService(_userId, movieId);
                return
                    new MovieDetail
                    {
                        MovieID = entity.MovieID,
                        MovieName = entity.MovieName,
                        Genre = entity.Genre,
                        Director = entity.Director,
                        AllReviews = reviewService.GetAllReviewByMovieId(movieId),
                        CreatedUtc = entity.CreatedUtc,
                        UpdatedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews2
                        .Single(e => e.MovieID == model.MovieID && e.OwnerID == _userId);
                
                entity.MovieName = model.MovieName;
                entity.Genre = model.Genre;
                entity.Director = model.Director;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews2
                        .Single(e => e.MovieID == movieId && e.OwnerID == _userId);
                
                ctx.MovieReviews2.Remove(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
    

