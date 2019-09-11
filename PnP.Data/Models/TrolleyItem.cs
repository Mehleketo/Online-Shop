using System;

namespace PnP.Data.Models
{
    public class TrolleyItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TrolleyId { get; set; }
        public virtual Trolley Trolley { get; set; }
    }
}
