using System;
using System.Collections.Generic;

namespace PnP.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        //public string ImageUrl { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public string Features { get; set; }
        public string Usage { get; set; }
        public string Slug { get; set; }
        public DateTime DateCreated { get; set; }

        public int SubCategoryId { get; set; }
        public virtual ProductSubCategory SubCategory { get; set; }

        public virtual ICollection<ProductReview> Reviews { get; set; }
        public virtual ICollection<ProductDiscount> Discounts { get; set; }
    }
}
