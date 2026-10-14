using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Storage;

public class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<int, CustomerDataModel> _customerDataModels = new();
    
    public CustomerDataModel Create(CustomerDataModel customer)
    {
        var idToUse = 1;
        if(_customerDataModels.Keys.Any())
            idToUse = _customerDataModels.Keys.Max() + 1;
        
        customer.Id = idToUse;
        
        _customerDataModels[idToUse] = customer;
        
        return _customerDataModels[idToUse];
    }

    public CustomerDataModel? GetById(int id)
    {
        return _customerDataModels.GetValueOrDefault(id);
    }

    public List<CustomerDataModel> GetCustomers()
    {
        return _customerDataModels.Values.ToList();
    }

    public bool DeleteById(int id)
    {
        return _customerDataModels.Remove(id);
    }

    // Full destructive update aka overwrite object with new object
    public CustomerDataModel Update(CustomerDataModel customer)
    {
        _customerDataModels[customer.Id] = customer;
        return _customerDataModels[customer.Id];
    }
}