using PnP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProductReviewService
    {
        Task Create(ProductReview _review);
        Task Edit(ProductReview _review);
        Task Remove(int _id);

        Task<IEnumerable<ProductReview>> GetAll();
        Task<IEnumerable<ProductReview>> GetByProductId(int _productId);
        Task<IEnumerable<ProductReview>> GetByUserId(string _userId);

        Task<ProductReview> GetById(int _id);
    }
}
