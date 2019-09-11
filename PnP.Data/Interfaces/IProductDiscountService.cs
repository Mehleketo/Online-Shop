using PnP.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Data.Interfaces
{
    public interface IProductDiscountService
    {
        Task Create(ProductDiscount _discount);
        Task Edit(ProductDiscount _discount);
        Task Remove(int _id);

        Task<IEnumerable<ProductDiscount>> GetAll();
        Task<IEnumerable<ProductDiscount>> GetByProductId(int _productId);
        Task<IEnumerable<ProductDiscount>> GetByDate(DateTime _date);

        Task<ProductDiscount> GetById(int _id);
    }
}
