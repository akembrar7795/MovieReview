using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class ReviewListItem
    {
        public int ReviewID { get; set; }
        public Guid OwnerID { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
