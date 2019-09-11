using System;

namespace PnP.Data.Models
{
    public class RewardsCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
