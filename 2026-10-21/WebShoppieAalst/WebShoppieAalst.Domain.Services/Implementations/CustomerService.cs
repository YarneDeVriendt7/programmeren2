using WebShoppie.Api.Contracts.Customer;
using WebShoppieAalst.Domain.Services.Interfaces;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Domain.Services.Interfaces.Services;
using WebShoppieAalst.Domain.Services.MappingExtensions;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.Implementations;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public CustomerResponseContract CreateCustomer(CustomerRequestContract customerToCreate)
    {
        return repository.Create(customerToCreate.AsDataModel()).AsContract(); 
    }

    public CustomerResponseContract? GetCustomerById(int id)
    {
        return repository.GetById(id)?.AsContract();
    }

    public List<CustomerOverviewResponseContract> GetCustomers()
    {
        return repository.GetCustomers()
            .Select(c => c.AsOverviewContract())
            .ToList();
    }

    public bool DeleteCustomer(int id)
    {
        return repository.DeleteById(id);
    }

    public CustomerResponseContract UpdateCustomer(int id, CustomerRequestContract customerToUpdate)
    {
        var incomingUpdate = customerToUpdate.AsDataModel();
        incomingUpdate.CustomerId = id;
        
        return repository.Update(incomingUpdate).AsContract();
    }
}