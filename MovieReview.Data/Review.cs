using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data
{
    
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int MovieID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Reviews { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
