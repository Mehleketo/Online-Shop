using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IUserAddressService
    {
        Task Create(UserAddress _userAddress);
        Task Edit(UserAddress _userAddress);
        Task Remove(int _id);

        Task<IEnumerable<UserAddress>> GetAll();
        Task<IEnumerable<UserAddress>> GetByUserId(string _userId);

        Task<UserAddress> GetById(int _id);
    }
}
