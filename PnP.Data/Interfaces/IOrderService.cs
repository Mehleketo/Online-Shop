using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(Order _order);
        Task EditAsync(Order _order);
        Task RemoveAsync(int _id);

        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetByUserIdAsync(string _userId);

        Task<Order> GetById(int _id);
    }
}
