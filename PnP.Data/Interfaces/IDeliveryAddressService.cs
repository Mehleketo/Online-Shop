using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IDeliveryAddressService
    {
        Task Create(DeliveryAddress _deliveryAddress);
        Task Edit(DeliveryAddress _deliveryAddress);
        Task Remove(int _id);

        Task<IEnumerable<DeliveryAddress>> GetAll();
        Task<IEnumerable<DeliveryAddress>> GetByUserId(string _userId);

        Task<DeliveryAddress> GetById(int _id);
    }
}
