using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ISupplierService
    {
        Task Create(Supplier _supplier);
        Task Edit(Supplier _supplier);
        Task Remove(int _id);

        Task<IEnumerable<Supplier>> GetAll();

        Task<Supplier> GetById(int _id);
        Task<Supplier> GetBySlug(string _slug);
    }
}
