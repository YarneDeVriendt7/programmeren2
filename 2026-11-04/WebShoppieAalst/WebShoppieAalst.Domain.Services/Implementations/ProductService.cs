using WebShoppie.Api.Contracts.Products;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Domain.Services.Interfaces.Services;
using WebShoppieAalst.Domain.Services.MappingExtensions;

namespace WebShoppieAalst.Domain.Services.Implementations;

public class ProductService(IProductRepository repository) : IProductService
{
    public ProductResponseContract CreateProduct(ProductRequestContract productToCreate)
    {
        var dataModel = productToCreate.AsDataModel();
        var created = repository.Create(dataModel);

        return created.AsContract();
    }

    public ProductResponseContract? GetById(int id)
    {
        var product = repository.GetById(id);

        return product?.AsContract();
    }

    public IEnumerable<ProductResponseContract> GetAllProducts()
    {
        return repository.GetAll().Select(product => product.AsContract());
    }

    public bool DeleteProduct(int productId)
    {
        return repository.Delete(productId);
    }

    public ProductResponseContract UpdateProduct(int id, ProductRequestContract productToUpdate)
    {
        var dataModel = productToUpdate.AsDataModel();
        dataModel.ProductId = id;
        var updated = repository.Update(dataModel);

        return updated.AsContract();
    }
}