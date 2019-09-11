using System;
using System.Collections.Generic;

namespace PnP.Data.Models
{
    public class GroceryList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public virtual ICollection<GroceryListItem> GroceryListItems { get; set; }
    }
}
