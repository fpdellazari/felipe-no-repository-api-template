using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;

public record UpdateCustomerDTO(string Name, int Age, string? Email);

