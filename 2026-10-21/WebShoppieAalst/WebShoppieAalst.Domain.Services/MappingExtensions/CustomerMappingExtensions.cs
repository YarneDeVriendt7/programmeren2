using WebShoppie.Api.Contracts.Customer;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.MappingExtensions;

public static class CustomerMappingExtensions
{
    public static CustomerResponseContract AsContract(this CustomerDataModel dbCustomer)
    {
        return new CustomerResponseContract()
        {
            Id = dbCustomer.CustomerId,
            DateOfBirth =  dbCustomer.DateOfBirth,
            Country =  dbCustomer.Country,
            FirstName = dbCustomer.FirstName,
            LastName = dbCustomer.LastName,
            Email = dbCustomer.Email,
            Address =  dbCustomer.Addressline1 
                       + " " + dbCustomer.Addressline2 
                       + " " + dbCustomer.Addressline3,
        };
    }

    public static CustomerOverviewResponseContract AsOverviewContract(this CustomerDataModel dbCustomer)
    {
        return new CustomerOverviewResponseContract()
        {
            Id = dbCustomer.CustomerId,
            Country = dbCustomer.Country,
            Email = dbCustomer.Email,
            SalesTotal = 10000
        };
    }

    public static CustomerDataModel AsDataModel(this CustomerRequestContract customerRequestContract)
    {
        return new CustomerDataModel()
        {
            FirstName = customerRequestContract.FirstName,
            LastName = customerRequestContract.LastName,
            Email = customerRequestContract.Email,
            Addressline1 =  customerRequestContract.Addressline1,
            Addressline2 = customerRequestContract.Addressline2,
            Addressline3 =  customerRequestContract.Addressline3,
            Country =  customerRequestContract.Country,
            DateOfBirth = customerRequestContract.DateOfBirth ?? throw new ArgumentNullException(nameof(customerRequestContract.DateOfBirth))
        };
    }
    
}