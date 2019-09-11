using System;

namespace PnP.Data.Models
{
    public class LoyaltyCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
