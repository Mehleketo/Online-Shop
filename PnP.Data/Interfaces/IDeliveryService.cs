using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IDeliveryService
    {
        Task CreateAsync(Delivery _delivery);
        Task EditAsync(Delivery _delivery);
        Task RemoveAsync(int _id);

        Task<IEnumerable<Delivery>> GetAllAsync();
        Task<IEnumerable<Delivery>> GetByUserIdAsync(string _userId);

        Task<Delivery> GetById(int _id);
    }
}
