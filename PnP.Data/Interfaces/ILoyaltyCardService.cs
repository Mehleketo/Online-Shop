using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface ILoyaltyCardService
    {
        Task Create(LoyaltyCard _card);
        Task Edit(LoyaltyCard _card);
        Task Remove(int _id);

        Task<IEnumerable<LoyaltyCard>> GetAll();
        Task<IEnumerable<LoyaltyCard>> GetByUserId(string _userId);

        Task<LoyaltyCard> GetById(int _id);
    }
}
