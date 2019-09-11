using System;

namespace PnP.Data.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
