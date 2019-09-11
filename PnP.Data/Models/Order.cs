using System;

namespace PnP.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int StatusId { get; set; }
        public virtual OrderStatus Status { get; set; }

        public int TrolleyId { get; set; }
        public virtual Trolley Trolley { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
