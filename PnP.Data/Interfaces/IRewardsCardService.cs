using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IRewardsCardService
    {
        Task Create(RewardsCard _card);
        Task Edit(RewardsCard _card);
        Task Remove(int _id);

        Task<IEnumerable<RewardsCard>> GetAll();
        Task<IEnumerable<RewardsCard>> GetByUserId(string _userId);

        Task<RewardsCard> GetById(int _id);
    }
}
