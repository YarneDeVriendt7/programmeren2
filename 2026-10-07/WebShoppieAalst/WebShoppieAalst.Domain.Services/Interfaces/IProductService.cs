using System;
using System.Collections.Generic;
using System.Text;
using WebShoppie.Api.Contracts.Products;

namespace WebShoppieAalst.Domain.Services.Interfaces
{
    public interface IProductService
    {
        ProductResponseContract CreateProduct(ProductRequestContract productToCreate);
        ProductResponseContract GetProductById(int productId);
    }
}
