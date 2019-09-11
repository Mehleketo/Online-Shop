using System;

namespace PnP.Data.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateCreated { get; set; }

        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
