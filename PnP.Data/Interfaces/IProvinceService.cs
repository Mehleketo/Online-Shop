using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProvinceService
    {
        Task Create(Province _province);
        Task Edit(Province _province);
        Task Remove(int _id);

        Task<IEnumerable<Province>> GetAll();

        Task<Province> GetById(int _id);
    }
}
