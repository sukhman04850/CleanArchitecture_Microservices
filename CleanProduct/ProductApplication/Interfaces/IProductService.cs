using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApplication.DTO;

namespace ProductApplication.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductsDTO>> GetAllProducts();
        Task<ProductsDTO> GetProductById(Guid id);
        Task<ProductsDTO> AddProduct(ProductsDTO product);
        Task<ProductsDTO> UpdateProduct(ProductsDTO product);
        Task<bool> DeleteProduct(Guid id);
    }
}
