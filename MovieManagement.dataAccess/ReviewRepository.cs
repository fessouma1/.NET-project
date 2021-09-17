using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.dataAccess
{
    class ReviewRepository : BaseRepository
    {
        public List<Review> SearchReviews()
        {
            return DBContext.Reviews.ToList();
        }

        public Review GetReviews(Guid ReviewsId)
        {
            var reviews = DBContext.Reviews.FirstOrDefault(a => a.id == ReviewsId);
            return reviews;
        }

        public void AddReview(Review NewReview)
        {
            DBContext.Reviews.Add(NewReview);
            DBContext.SaveChanges();
        }

        public void DeleteReview(Guid ReviewId)
        {

            var review = DBContext.Reviews.FirstOrDefault(a => a.id == ReviewId);
            if (review != null)
            {
                DBContext.Reviews.Remove(review);
                DBContext.SaveChanges();
            }
        }

        public void UpdateReview(Review updatedReview)
        {

            var existingReview = DBContext.Reviews.FirstOrDefault(a => a.id == updatedReview.id);
            if (existingReview != null)
            {
                existingReview.Score = updatedReview.Score;
                DBContext.SaveChanges();
            }
        }
    }
}
