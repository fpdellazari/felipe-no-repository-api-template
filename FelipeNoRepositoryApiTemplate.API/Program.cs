using FluentValidation;
using FelipeNoRepositoryApiTemplate.Application.Data;
using FelipeNoRepositoryApiTemplate.Application.Mapper;
using FelipeNoRepositoryApiTemplate.Application.Services;
using FelipeNoRepositoryApiTemplate.Application.Validators;
using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    options.UseSqlite(connectionString);
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Services
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Validadores com Fluent Validation
builder.Services.AddScoped<IValidator<CreateUpdateCustomerDTO>, CreateUpdateCustomerValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
