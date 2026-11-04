using WebShoppie.Api.Contracts.Products;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.MappingExtensions;

public static class ProductMappingExtensions
{
    public static ProductResponseContract AsContract(this ProductDataModel dataModel)
    {
        return new ProductResponseContract
        {
            ProductId = dataModel.ProductId,
            Title = dataModel.Title,
            Description = dataModel.Description,
            Price = dataModel.Price,
            StockCount = dataModel.StockCount
        };
    }

    public static ProductDataModel AsDataModel(this ProductRequestContract contract)
    {
        return new ProductDataModel
        {
            Title = contract.Title,
            Description = contract.Description,
            Price = contract.Price,
            StockCount = contract.StockCount
        };
    }
}