using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IContactDetailService
    {
        Task Create(ContactDetail _contactDetail);
        Task Edit(ContactDetail _contactDetail);
        Task Remove(int _id);

        Task<IEnumerable<ContactDetail>> GetAll();
        Task<IEnumerable<ContactDetail>> GetByUserId(string _userId);

        Task<ContactDetail> GetById(int _id);
    }
}
