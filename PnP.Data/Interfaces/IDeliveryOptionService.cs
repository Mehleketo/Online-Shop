using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IDeliveryOptionService
    {
        Task CreateAsync(DeliveryOption _deliveryOption);
        Task EditAsync(DeliveryOption _deliveryOption);
        Task RemoveAsync(int _id);

        Task<IEnumerable<DeliveryOption>> GetAllAsync();

        Task<DeliveryOption> GetById(int _id);
    }
}
