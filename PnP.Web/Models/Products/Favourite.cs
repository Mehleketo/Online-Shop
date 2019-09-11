using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Web.Models.Products
{
    public class Favourite
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ProductImage { get; set; }
    }
}
