using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IOrderStatusService
    {
        Task CreateAsync(OrderStatus _orderStatus);
        Task EditAsync(OrderStatus _orderStatus);
        Task RemoveAsync(int _id);

        Task<IEnumerable<OrderStatus>> GetAllAsync();

        Task<OrderStatus> GetById(int _id);
    }
}
