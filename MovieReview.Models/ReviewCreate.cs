using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class ReviewCreate
    {
        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public int MovieID { get; set; }

        public string YourReview { get; set; }

    }
}
