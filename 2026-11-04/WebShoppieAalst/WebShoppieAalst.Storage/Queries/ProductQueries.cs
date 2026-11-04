namespace WebShoppie.Storage.Queries;

public class ProductQueries
{
    private string? _getProductById;
    private string? _createProduct;

    
    public string CreateProduct => _createProduct ??= File.ReadAllText(AppContext.BaseDirectory + "/Queries/Products/" + nameof(CreateProduct) + ".sql");
    
    public string GetProductById => _getProductById ??= File.ReadAllText(AppContext.BaseDirectory + "/Queries/Products/" + "GetProductById.sql");

}