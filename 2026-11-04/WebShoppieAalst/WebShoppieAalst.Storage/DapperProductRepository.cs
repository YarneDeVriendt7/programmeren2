using Dapper;
using Npgsql;
using WebShoppie.Storage.Queries;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Storage;

public class DapperProductRepository(ProductQueries productQueries) : IProductRepository
{
    private readonly string _connectionString = "Server=localhost;Port=5432;Userid=admin;Password=secret;Database=pg2db";

    public ProductDataModel Create(ProductDataModel product)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var id = connection.ExecuteScalar<int>(productQueries.CreateProduct, product);

        return GetById(id) ?? throw new InvalidOperationException(
            $"Product {product.Title} could not be created");
    }

    public ProductDataModel? GetById(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.QuerySingleOrDefault<ProductDataModel>(productQueries.GetProductById, new { id });
    }

    public IEnumerable<ProductDataModel> GetAll()
    {
        const string sql = "SELECT * FROM storefront.products";

        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<ProductDataModel>(sql);
    }

    public bool Delete(int productId)
    {
        const string sql = "DELETE FROM storefront.products WHERE ProductId = @id";

        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Execute(sql, new { id = productId }) == 1;
    }

    public ProductDataModel Update(ProductDataModel product)
    {
        const string sql =
            """
            UPDATE storefront.products
            SET title = @title,
                description = @description,
                price = @price,
                stockcount = @stockcount
            WHERE ProductId = @productId
            """;

        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = connection.Execute(sql, product);

        return affectedRows == 1 
            ? GetById(product.ProductId)! 
            : throw new InvalidOperationException($"Product {product.ProductId} could not be updated");
    }
}