using WebShoppie.Api.Contracts.Orders;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Domain.Services.Interfaces.Services;
using WebShoppieAalst.Storage.DataModel;

namespace WebShoppieAalst.Domain.Services.Implementations;

public class OrderService(IOrderRepository repository, IProductService productService, ICustomerService customerService) : IOrderService
{
    public OrderResponseContract CreateOrder(OrderRequestContract orderToCreate)
    {
        //inline mapping omdat er logica in zit die we niet willen verstoppen
        var orderDataModel = new OrderDataModel()
        {
            CustomerId = orderToCreate.CustomerId,
            OrderDate = DateTime.Now,
            TotalPrice = orderToCreate.OrderProducts
                .Select( op => productService.GetById(op.ProductId).Price * op.Quantity)
                .Sum()
        };

        var orderProductDataModels = orderToCreate.OrderProducts
            .Select(op => new OrderProductDataModel
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity,
                Price = productService.GetById(op.ProductId).Price
            });
        
        var createdOrder = repository.Create(orderDataModel, orderProductDataModels);

        var orderResponseContract = new OrderResponseContract()
        {
            CustomerId = createdOrder.CustomerId,
            OrderDate = createdOrder.OrderDate,
            TotalPrice = createdOrder.TotalPrice,
            OrderId = createdOrder.OrderId,
            CustomerEmail = customerService.GetCustomerById(createdOrder.CustomerId).Email,
            OrderProducts = repository.GetOrderProductsByOrderId(createdOrder.OrderId).Select(opdm =>
                new OrderProductResponseContract
                {
                    Price = opdm.Price,
                    ProductId = opdm.ProductId,
                    Quantity = opdm.Quantity,
                    OrderProductId = opdm.OrderProductId,
                    ProductName = productService.GetById(opdm.ProductId).Title
                })
        };
        
        return orderResponseContract;
    }

    public OrderResponseContract GetOrder(int orderId)
    {
        throw new NotImplementedException();
    }
}