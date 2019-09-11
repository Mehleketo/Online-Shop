using System;

namespace PnP.Data.Models
{
    public class GroceryListItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }

        public int GroceryListId { get; set; }
        public virtual GroceryList GroceryList { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
