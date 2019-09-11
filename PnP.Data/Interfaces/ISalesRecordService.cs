using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ISalesRecordService
    {
        Task CreateAsync(SalesRecord _salesRecord);
        Task EditAsync(SalesRecord _salesRecord);
        Task RemoveAsync(int _id);

        Task<IEnumerable<SalesRecord>> GetAllAsync();
        Task<IEnumerable<SalesRecord>> GetByUserIdAsync(string _userId);

        Task<SalesRecord> GetById(int _id);
    }
}
