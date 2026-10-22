using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Customer;
using WebShoppieAalst.Domain.Services.Interfaces;
using WebShoppieAalst.Domain.Services.Interfaces.Services;

namespace WebShoppieAalst.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(ICustomerService _customerService) : ControllerBase
{
    // Maak klant
    [HttpPost]
    public ActionResult<CustomerResponseContract> CreateCustomer(
        [FromBody]CustomerRequestContract customer)
    {
        var created = _customerService.CreateCustomer(customer);
        return Ok(created);
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerResponseContract> GetById([FromRoute]int id)
    {
        var customer = _customerService.GetCustomerById(id);
        if (customer is not null)
            return Ok(customer);
        return NotFound();
    }
    
    [HttpGet()]
    public ActionResult<List<CustomerOverviewResponseContract>> GetAll()
    {
        var customers = _customerService.GetCustomers();
        return Ok(customers);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer([FromRoute] int id)
    {
        if(_customerService.DeleteCustomer(id))
            return NoContent();
        return BadRequest();
    }

    [HttpPut("{id}")]
    public ActionResult<CustomerResponseContract> UpdateCustomer(
        [FromRoute] int id,
        [FromBody] CustomerRequestContract customer)
    {
        var updated = _customerService.UpdateCustomer(id, customer);
        return Ok(updated);
    }
}