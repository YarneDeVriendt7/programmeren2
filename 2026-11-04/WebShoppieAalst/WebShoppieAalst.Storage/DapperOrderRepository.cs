using Dapper;
using Npgsql;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Storage;

public class DapperOrderRepository : IOrderRepository
{
    private readonly string _connectionString = "Server=localhost;Port=5432;Userid=admin;Password=secret;Database=pg2db";

    public OrderDataModel? GetById(int orderId)
    {
        const string sql = "select * from storefront.Orders where OrderId = @orderId";

        using var connection = new NpgsqlConnection(_connectionString);
        
        var orderDataModel = connection.QuerySingleOrDefault<OrderDataModel>(sql, new { orderId });
        return orderDataModel;
    }

    public IEnumerable<OrderDataModel> GetAllOrders()
    {
        const string sql = "select * from storefront.Orders";

        using var connection = new NpgsqlConnection(_connectionString);
        
        var orderDataModels = connection.Query<OrderDataModel>(sql);
        return orderDataModels;    
    }

    public IEnumerable<OrderProductDataModel> GetOrderProductsByOrderId(int orderId)
    {
        const string sql = "select * from storefront.OrderProducts where OrderId = @orderId";

        using var connection = new NpgsqlConnection(_connectionString);
        
        var orderProductDataModels = connection.Query<OrderProductDataModel>(sql, new { orderId });
        return orderProductDataModels;      
    }

    public OrderDataModel Create(OrderDataModel order, IEnumerable<OrderProductDataModel> orderProducts)
    {
        const string orderSql = 
            """
            insert into storefront.orders ( orderdate, customerid, totalprice)
            values (@orderDate, @customerid, @totalprice)
            returning orderid
            """;

        const string orderProductSql = 
            """
            insert into storefront.orderproducts (orderid, productid, quantity, price)
            values (@orderid, @productid, @quantity, @price)
            """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var transaction = connection.BeginTransaction();
        
        // insert order
        var orderId = connection.ExecuteScalar<int>(orderSql, order, transaction);

        // set created order id on orderProducts to be inserted
        foreach (var orderProductDataModel in orderProducts)
        {
            orderProductDataModel.OrderId = orderId;
            // insert orderProducts
            connection.Execute(orderProductSql, orderProductDataModel, transaction);
        }
        
        transaction.Commit();

        return GetById(orderId)!;
    }
}