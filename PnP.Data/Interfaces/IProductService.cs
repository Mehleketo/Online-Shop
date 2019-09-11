using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProductService
    {
        Task Create(Product _product);
        Task Edit(Product _product);
        Task Remove(int _id);

        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetBySubcategoryId(int _categoryId);

        Task<Product> GetById(int _id);
        Task<Product> GetBySlug(string _slug);
    }
}
