using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IGroceryListItemService
    {
        Task Create(GroceryListItem _groceryListItem);
        Task Edit(GroceryListItem _groceryListItem);
        Task Remove(int _id);

        Task<IEnumerable<GroceryListItem>> GetAll();
        Task<IEnumerable<GroceryListItem>> GetByGroceryListId(int _groceryListId);

        Task<GroceryListItem> GetById(int _id);
    }
}
