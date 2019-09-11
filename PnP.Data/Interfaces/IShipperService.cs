using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IShipperService
    {
        Task CreateAsync(Shipper _shipper);
        Task EditAsync(Shipper _shipper);
        Task RemoveAsync(int _id);

        Task<IEnumerable<Shipper>> GetAllAsync();

        Task<Shipper> GetById(int _id);
        Task<Shipper> GetBySlug(string _slug);
    }
}
