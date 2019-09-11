using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IGroceryListService
    {
        Task Create(GroceryList _groceryList);
        Task Edit(GroceryList _groceryList);
        Task Remove(int _id);

        Task<IEnumerable<GroceryList>> GetAll();
        Task<IEnumerable<GroceryList>> GetByUserId(string _userId);

        Task<GroceryList> GetById(int _id);
    }
}
