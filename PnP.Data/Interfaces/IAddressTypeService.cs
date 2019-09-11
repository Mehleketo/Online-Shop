using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IAddressTypeService
    {
        Task Create(AddressType _addressType);
        Task Remove(int _id);

        Task<IEnumerable<AddressType>> GetAll();

        Task<AddressType> GetById(int _id);
    }
}
