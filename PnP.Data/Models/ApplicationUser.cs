using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace PnP.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public bool IsSubscribed { get; set; }

        public int IdentificationTypeId { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public int StatusId { get; set; }
        public virtual UserStatus Status { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<LoyaltyCard> LoyaltyCards { get; set; }
        public virtual ICollection<RewardsCard> RewardsCards { get; set; }
        public virtual ICollection<ProductReview> Reviews { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual ICollection<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual ICollection<GroceryList> GroceryLists { get; set; }
        public virtual ICollection<Trolley> Trolleys { get; set; }
        public virtual ICollection<SalesRecord> SalesRecords { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
