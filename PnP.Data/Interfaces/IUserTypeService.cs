using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IUserTypeService
    {
        Task Create(UserType _userType);
        Task Edit(UserType _userType);
        Task Remove(int _id);

        Task<IEnumerable<UserType>> GetAll();

        Task<UserType> GetById(int _id);
    }
}
