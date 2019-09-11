using System;

namespace PnP.Data.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Instructions { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }

        public int DeliveryAddressId { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }

        public int DeliveryOptionId { get; set; }
        public virtual DeliveryOption DeliveryOption { get; set; }

        public int DeliveryTypeId { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }

        public int StatusId { get; set; }
        public virtual DeliveryStatus Status { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
