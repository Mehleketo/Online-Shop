using System;
using System.Collections.Generic;

namespace PnP.Data.Models
{
    public class Trolley
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int StatusId { get; set; }
        public virtual TrolleyStatus Status { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual IEnumerable<TrolleyItem> TrolleyItems { get; set; }
    }
}
