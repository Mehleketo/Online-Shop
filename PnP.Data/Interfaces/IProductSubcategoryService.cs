using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProductSubcategoryService
    {
        Task Create(ProductSubCategory _subcategory);
        Task Edit(ProductSubCategory _subcategory);
        Task Remove(int _id);

        Task<IEnumerable<ProductSubCategory>> GetAll();
        Task<IEnumerable<ProductSubCategory>> GetByCategoryId(int _categoryId);

        Task<ProductSubCategory> GetById(int _id);
        Task<ProductSubCategory> GetBySlug(string _slug);
    }
}
