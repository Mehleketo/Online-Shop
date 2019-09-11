using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IIdentificationTypeService
    {
        Task Create(IdentificationType _idType);
        Task Edit(IdentificationType _idType);
        Task Remove(int _id);

        Task<IEnumerable<IdentificationType>> GetAll();

        Task<IdentificationType> GetById(int _id);
    }
}
