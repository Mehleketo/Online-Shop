using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ITrolleyStatusService
    {
        Task Create(TrolleyStatus _trolleyStatus);
        Task Edit(TrolleyStatus _trolleyStatus);
        Task Remove(int _id);

        Task<IEnumerable<TrolleyStatus>> GetAll();

        Task<TrolleyStatus> GetById(int _id);
    }
}
