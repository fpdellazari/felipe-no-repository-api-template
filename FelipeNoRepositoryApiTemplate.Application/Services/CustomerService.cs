using AutoMapper;
using FelipeNoRepositoryApiTemplate.Application.Data;
using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Models.Entities;
using FelipeNoRepositoryApiTemplate.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace FelipeNoRepositoryApiTemplate.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CustomerService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;        
    }

    public async Task<CustomerDTO> CreateAsync(CreateUpdateCustomerDTO createCustomer)
    {
        var customer = new Customer()
        {
            Name = createCustomer.Name,
            Age = createCustomer.Age,
            Email = createCustomer.Email
        };

        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<CustomerDTO> DeleteAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<IEnumerable<CustomerDTO>> GetAsync()
    {
        var customers = await _dbContext.Customers.AsNoTracking().ToListAsync();

        return _mapper.Map<List<CustomerDTO>>(customers); ;
    }

    public async Task<CustomerDTO> GetByIdAsync(Guid id)
    {
        var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<CustomerDTO> UpdateAsync(Guid id, CreateUpdateCustomerDTO updateCustomer)
    {
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer is null) throw new KeyNotFoundException("Cliente não encontrado.");

        customer.Name = updateCustomer.Name;
        customer.Age = updateCustomer.Age;
        customer.Email = updateCustomer.Email;

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(customer);
    }
}

