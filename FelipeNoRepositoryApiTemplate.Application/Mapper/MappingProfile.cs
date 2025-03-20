using AutoMapper;
using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FelipeNoRepositoryApiTemplate.Domain.Models.Entities;

namespace FelipeNoRepositoryApiTemplate.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}

