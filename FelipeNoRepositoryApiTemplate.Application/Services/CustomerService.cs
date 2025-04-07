using FelipeNoRepositoryApiTemplate.Application.Data;
using FelipeNoRepositoryApiTemplate.Application.Mappers;
using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace FelipeNoRepositoryApiTemplate.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerDTO> CreateAsync(CreateUpdateCustomerDTO createUpdateCustomer)
    {
        var customer = createUpdateCustomer.MapToCustomer();
    
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return customer.MapToDTO();
    }

    public async Task<CustomerDTO> DeleteAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();

        return customer.MapToDTO();
    }

    public async Task<IEnumerable<CustomerDTO>> GetAsync()
    {
        var customers = await _dbContext.Customers.AsNoTracking().ToListAsync();

        return customers.MapToDTOList();
    }

    public async Task<CustomerDTO> GetByIdAsync(Guid id)
    {
        var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        return customer.MapToDTO();
    }

    public async Task<CustomerDTO> UpdateAsync(Guid id, CreateUpdateCustomerDTO createUpdateCustomer)
    {
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        customer.Name = createUpdateCustomer.Name;
        customer.Age = createUpdateCustomer.Age;
        customer.Email = createUpdateCustomer.Email;

        await _dbContext.SaveChangesAsync();

        return customer.MapToDTO();
    }
}

