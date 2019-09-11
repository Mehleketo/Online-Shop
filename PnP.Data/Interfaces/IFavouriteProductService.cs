using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IFavouriteProductService
    {
        Task Create(FavouriteProduct _favourite);
        Task Remove(int _id);

        Task<IEnumerable<FavouriteProduct>> GetAll();
        Task<IEnumerable<FavouriteProduct>> GetByUserId(string _userId);

        Task<FavouriteProduct> GetById(int _id);
    }
}
