using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.Interfaces.Repositories;

public interface IProductRepository
{
    ProductDataModel Create(ProductDataModel product);
    ProductDataModel? GetById(int id);
    IEnumerable<ProductDataModel> GetAll();
    bool Delete(int productId);
    ProductDataModel Update(ProductDataModel product);
}