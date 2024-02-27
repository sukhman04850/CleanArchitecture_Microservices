using AutoMapper;
using ProductApplication.DTO;
using ProductApplication.Interfaces;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductsDTO> AddProduct(ProductsDTO product)
        {
            var productAdd = _mapper.Map<Products>(product);
            var newProduct = await _repository.AddProduct(productAdd);
            var addedProduct = _mapper.Map<ProductsDTO>(newProduct);
            return addedProduct;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var removeProduct = await _repository.DeleteProduct(id);
            return removeProduct;
        }

        public async Task<List<ProductsDTO>> GetAllProducts()
        {
            var allProducts = await _repository.GetAllProducts();
            var products = _mapper.Map<List<ProductsDTO>>(allProducts);
            return products;
        }

        public async Task<ProductsDTO> GetProductById(Guid id)
        {
            var product = await _repository.GetProductById(id);
            var productById = _mapper.Map<ProductsDTO>(product);
            return productById;
        }

        public async Task<ProductsDTO> UpdateProduct(ProductsDTO product)
        {
            var updateRequest = _mapper.Map<Products>(product);
            var updatedProduct = await _repository.UpdateProduct(updateRequest);
            var finalProduct = _mapper.Map<ProductsDTO>(updatedProduct);
            return finalProduct;
        }

    }
}
