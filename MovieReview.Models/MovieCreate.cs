using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class MovieCreate
    {
        [Required]
        public string MovieName { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Director { get; set; }

        public override string ToString() => MovieName;
    }
}
