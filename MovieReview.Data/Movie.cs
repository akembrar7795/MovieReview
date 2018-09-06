using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
