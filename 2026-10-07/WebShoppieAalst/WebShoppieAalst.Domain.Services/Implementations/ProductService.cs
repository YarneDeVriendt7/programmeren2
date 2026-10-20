using System;
using System.Collections.Generic;
using System.Text;
using WebShoppie.Api.Contracts.Customer;
using WebShoppie.Api.Contracts.Products;
using WebShoppieAalst.Domain.Services.Interfaces;

namespace WebShoppieAalst.Domain.Services.Implementations
{
    public class ProductService : IProductService
    {
        public ProductResponseContract CreateProduct(ProductRequestContract productToCreate)
        {
            return new ProductResponseContract
            {
                Id = 1,
                Name = productToCreate.Name,
                Description = productToCreate.Description,
                Price = productToCreate.Price,
                AgeRating = productToCreate.AgeRating,
                StockCount = productToCreate.StockCount,
            };
        }

        public ProductResponseContract? GetProductById(int productId)
        {
            if (productId == 1)
                return new ProductResponseContract()
                {
                    Id = 1,
                    Name = "Test"
                };
            return null;
        }
    }
}
