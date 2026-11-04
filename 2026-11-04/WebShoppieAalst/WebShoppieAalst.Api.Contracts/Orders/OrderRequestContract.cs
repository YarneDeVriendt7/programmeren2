using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts.Orders;

public class OrderRequestContract
{
    [Required]
    public required int CustomerId { get; set; }
    [MinLength(1)]
    public required IEnumerable<OrderProductRequestContract> OrderProducts { get; set; }
}

public class OrderProductRequestContract
{
    [Required]
    public required int ProductId { get; set; }
    [Range(1,100)]
    public required int Quantity { get; set; }
}

