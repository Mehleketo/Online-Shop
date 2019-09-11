using System;

namespace PnP.Data.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
