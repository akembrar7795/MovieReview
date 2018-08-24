using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class ReviewEdit
    {
        [Required]
        public int ReviewID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string Review { get; set; }

    }
}
