using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Models.Entities;

namespace FelipeNoRepositoryApiTemplate.Application.Mappers;

public static class CustomerMapper
{
    public static Customer MapToCustomer(this CreateUpdateCustomerDTO createUpdateCustomer)
    {
        return new Customer
        {
            Name = createUpdateCustomer.Name,
            Age = createUpdateCustomer.Age,
            Email = createUpdateCustomer.Email
        };
    }

    public static CustomerDTO MapToDTO(this Customer customer)
    {
        return new CustomerDTO(
            Id: customer.Id,
            Name: customer.Name,
            Age: customer.Age,
            Email: customer.Email
        );
    }

    public static IEnumerable<CustomerDTO> MapToDTOList(this IEnumerable<Customer> customers)
    {
        return customers.Select(customer => customer.MapToDTO());
    }
}