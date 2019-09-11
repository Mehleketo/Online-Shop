using PnP.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PnP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<DeliveryOption> DeliveryOptions { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        public DbSet<FavouriteProduct> FavouriteProducts { get; set; }

        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<GroceryListItem> GroceryListItems { get; set; }

        public DbSet<IdentificationType> IdentificationTypes { get; set; }

        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

        public DbSet<RewardsCard> RewardsCards { get; set; }

        //public DbSet<Status> Statuses { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

        public DbSet<Trolley> Trolleys { get; set; }
        public DbSet<TrolleyItem> TrolleyItems { get; set; }
        public DbSet<TrolleyStatus> TrolleyStatuses { get; set; }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
    }
}
