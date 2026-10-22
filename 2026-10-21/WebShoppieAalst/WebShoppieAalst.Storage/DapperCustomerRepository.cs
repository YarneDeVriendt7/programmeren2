using Dapper;
using Npgsql;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Storage;

public class DapperCustomerRepository : ICustomerRepository
{
    private readonly string _connectionString = "Server=localhost;Port=5432;Userid=admin;Password=secret;Database=pg2db";
    
    public CustomerDataModel Create(CustomerDataModel customer)
    {
        var sql = """
                  INSERT INTO storefront.customers
                  (firstname, lastname, dateofbirth, email, addressline1, addressline2, addressline3, country)
                  VALUES
                      (@firstname, @lastname, @dateofbirth, @email, @addressline1, @addressline2, @addressline3, @country)
                  RETURNING customerid
                  """;
        
        using var connection = new NpgsqlConnection(_connectionString);
        var customerId = connection.ExecuteScalar<int>(sql, customer);
        return GetById(customerId) ?? throw new Exception("Customer not created");
    }

    public CustomerDataModel? GetById(int id)
    {
        var sql = """
                    SELECT * FROM storefront.customers WHERE customerId = @customerid
                  """;
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.QuerySingleOrDefault<CustomerDataModel>(sql, new { customerid = id });
    }

    public List<CustomerDataModel> GetCustomers()
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public CustomerDataModel Update(CustomerDataModel customer)
    {
        throw new NotImplementedException();
    }
}