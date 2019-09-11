using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IDeliveryStatusService
    {
        Task CreateAsync(DeliveryStatus _deliveryStatus);
        Task EditAsync(DeliveryStatus _deliveryStatus);
        Task RemoveAsync(int _id);

        Task<IEnumerable<DeliveryStatus>> GetAllAsync();

        Task<DeliveryStatus> GetById(int _id);
    }
}
