﻿using System.Collections.Generic;

namespace PnP.Data.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string ImageUrl { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public string Slug { get; set; }

        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
