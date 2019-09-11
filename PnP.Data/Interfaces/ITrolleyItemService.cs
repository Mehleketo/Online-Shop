using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ITrolleyItemService
    {
        Task Create(TrolleyItem _trolleyItem);
        Task Edit(TrolleyItem _trolleyItem);
        Task Remove(int _id);

        Task<IEnumerable<TrolleyItem>> GetAll();
        Task<IEnumerable<TrolleyItem>> GetByTrolleyIdAsync(int _trolleyId);

        Task<TrolleyItem> GetById(int _id);
    }
}
