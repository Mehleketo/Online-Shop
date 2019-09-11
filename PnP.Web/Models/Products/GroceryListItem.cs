using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Web.Models.Products
{
    public class GroceryListItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ProductImage { get; set; }
    }
}
