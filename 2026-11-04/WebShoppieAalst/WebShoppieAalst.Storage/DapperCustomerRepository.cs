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
        const string sql = "SELECT * FROM storefront.customers";
        
        using var connection = new NpgsqlConnection(_connectionString);
        
        var dbCustomers =  connection.Query<CustomerDataModel>( sql);
        
        return dbCustomers.ToList();
        
    }

    public bool DeleteById(int id)
    {
        const string sql = "DELETE FROM storefront.customers WHERE CustomerId = @id";
        
        using var connection = new NpgsqlConnection(_connectionString);
        
        var dbResult =  connection.Execute( sql, new { id = id });
        
        return dbResult == 1;
        
    }

    public CustomerDataModel Update(CustomerDataModel customer)
    {
        const string sql = 
            """
            UPDATE storefront.customers
            SET  firstname = @firstname,
                 lastname = @lastname,
                 dateofbirth = @dateofbirth,
                 email = @email,
                 addressline1 = @addressline1,
                 addressline2 = @addressline2,
                 addressline3 = @addressline3,
                 country = @country
            WHERE customerId = @customerId
            """;            
        
        using var connection = new NpgsqlConnection(_connectionString);
        
        var rowsAffected =  connection.Execute(sql, customer);

        return rowsAffected == 1
            ? GetById(customer.CustomerId)!
            : throw new InvalidOperationException($"Customer {customer.CustomerId} could not be updated");    
    }
    
}