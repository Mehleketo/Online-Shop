using System;

namespace PnP.Data.Models
{
    public class ProductDiscount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
