using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProductCategoryService
    {
        Task Create(ProductCategory _category);
        Task Edit(ProductCategory _category);
        Task Remove(int _id);

        Task<IEnumerable<ProductCategory>> GetAll();

        Task<ProductCategory> GetById(int _id);
        Task<ProductCategory> GetBySlug(string _slug);
    }
}
