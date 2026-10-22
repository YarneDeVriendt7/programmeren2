using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.Interfaces.Repositories;

public interface ICustomerRepository
{
    CustomerDataModel Create(CustomerDataModel customer);
    CustomerDataModel? GetById(int id);
    List<CustomerDataModel> GetCustomers();
    bool DeleteById(int id);
    CustomerDataModel Update(CustomerDataModel customer);
}