using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.Interfaces.Repositories;

public interface IOrderRepository
{
    // Read
    OrderDataModel? GetById(int orderId);
    IEnumerable<OrderDataModel> GetAllOrders();
    IEnumerable<OrderProductDataModel> GetOrderProductsByOrderId(int orderId);
    
    // Create
    OrderDataModel Create(OrderDataModel order, IEnumerable<OrderProductDataModel> orderProducts);
}