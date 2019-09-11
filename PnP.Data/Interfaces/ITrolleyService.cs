using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ITrolleyService
    {
        Task Create(Trolley _trolley);
        Task Edit(Trolley _trolley);
        Task Remove(int _id);

        Task<IEnumerable<Trolley>> GetAll();
        Task<IEnumerable<Trolley>> GetByUserIdAsync(string _userId);

        Task<Trolley> GetById(int _id);
        Task<Trolley> GetCurrent(string _userId);
    }
}
