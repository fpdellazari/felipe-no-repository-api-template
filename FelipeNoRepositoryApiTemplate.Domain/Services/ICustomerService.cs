using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;

namespace FelipeNoRepositoryApiTemplate.Domain.Services;

public interface ICustomerService
{
    Task<CustomerDTO> CreateAsync(CreateUpdateCustomerDTO createCustomer);
    Task<CustomerDTO> DeleteAsync(Guid id);
    Task<IEnumerable<CustomerDTO>> GetAsync();
    Task<CustomerDTO> GetByIdAsync(Guid id);
    Task<CustomerDTO> UpdateAsync(Guid id, CreateUpdateCustomerDTO updateCustomer);
}

