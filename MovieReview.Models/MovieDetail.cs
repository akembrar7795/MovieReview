using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class MovieDetail
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? UpdatedUtc { get; set; }

        public virtual ICollection<ReviewListItem> AllReviews { get; set; } = new List<ReviewListItem>();

    }
}
