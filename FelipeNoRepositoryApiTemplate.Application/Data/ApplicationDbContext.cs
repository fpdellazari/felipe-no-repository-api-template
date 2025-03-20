using FelipeNoRepositoryApiTemplate.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FelipeNoRepositoryApiTemplate.Application.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}

