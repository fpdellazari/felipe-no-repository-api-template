using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FelipeNoRepositoryApiTemplate.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;        
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerService.GetAsync();

        return Ok(customers);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        try
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO createCustomer, [FromServices] IValidator<CreateCustomerDTO> validator)
    {
        var validationResult = await validator.ValidateAsync(createCustomer);

        if (!validationResult.IsValid) return BadRequest(validationResult.ToDictionary());

        var customer = await _customerService.CreateAsync(createCustomer);

        return Ok(customer);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerDTO updateCustomer, [FromServices] IValidator<UpdateCustomerDTO> validator)
    {
        var validationResult = await validator.ValidateAsync(updateCustomer);

        if (!validationResult.IsValid) return BadRequest(validationResult.ToDictionary());

        try
        {
            var customer = await _customerService.UpdateAsync(id, updateCustomer);
            return Ok(customer);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            var customer = await _customerService.DeleteAsync(id);
            return Ok(customer);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

