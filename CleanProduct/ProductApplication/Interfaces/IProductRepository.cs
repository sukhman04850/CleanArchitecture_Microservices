using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(Guid id);
        Task<Products> AddProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<bool> DeleteProduct(Guid id);
    }
}
