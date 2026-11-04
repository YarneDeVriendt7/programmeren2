using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Orders;
using WebShoppieAalst.Domain.Services.Interfaces.Services;

namespace WebShoppieAalst.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController(IOrderService service): ControllerBase
{
    [HttpPost]
    public ActionResult<OrderResponseContract> CreateOrder(
        [FromBody] OrderRequestContract orderToCreate)
    {
        var createdOrder = service.CreateOrder(orderToCreate);
        return Ok(createdOrder); // verbeteren naar Created 201 wanneer mogelijk
    }
}