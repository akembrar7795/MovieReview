using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class MovieEdit
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
    }
}
