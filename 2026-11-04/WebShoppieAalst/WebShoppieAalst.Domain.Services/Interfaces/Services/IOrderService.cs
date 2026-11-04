using WebShoppie.Api.Contracts.Orders;

namespace WebShoppieAalst.Domain.Services.Interfaces.Services;

public interface IOrderService
{
    OrderResponseContract CreateOrder(OrderRequestContract orderToCreate);
    OrderResponseContract GetOrder(int orderId);
}