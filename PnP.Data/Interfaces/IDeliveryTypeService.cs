using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IDeliveryTypeService
    {
        Task CreateAsync(DeliveryType _deliveryType);
        Task EditAsync(DeliveryType _deliveryType);
        Task RemoveAsync(int _id);

        Task<IEnumerable<DeliveryType>> GetAllAsync();

        Task<DeliveryType> GetById(int _id);
    }
}
