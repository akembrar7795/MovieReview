using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class ReviewDetail
    {
        public int ReviewID { get; set; }
        public Guid OwnerID { get; set; }
        public string UserName { get; set; }
        public int MovieID { get; set; }
        public string Review { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display (Name = "Updated")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
