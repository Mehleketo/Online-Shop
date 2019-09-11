using System.Collections.Generic;

namespace PnP.Web.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public bool HasDiscount { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Image { get; set; }
        public string Features { get; set; }
        public string Usage { get; set; }
        public string Slug { get; set; }
        public int ReviewsCount { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
