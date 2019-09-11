using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IUserStatusService
    {
        Task Create(UserStatus _userStatus);
        Task Edit(UserStatus _userStatus);
        Task Remove(int _id);

        Task<IEnumerable<UserStatus>> GetAll();

        Task<UserStatus> GetById(int _id);
    }
}
