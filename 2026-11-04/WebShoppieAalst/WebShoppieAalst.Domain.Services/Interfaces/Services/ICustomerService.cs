using WebShoppie.Api.Contracts.Customer;

namespace WebShoppieAalst.Domain.Services.Interfaces.Services;

public interface ICustomerService
{
    CustomerResponseContract CreateCustomer(CustomerRequestContract customerToCreate);
    CustomerResponseContract? GetCustomerById(int id);
    List<CustomerOverviewResponseContract> GetCustomers();
    bool DeleteCustomer(int id);
    CustomerResponseContract UpdateCustomer(int id, CustomerRequestContract customerToUpdate);
}