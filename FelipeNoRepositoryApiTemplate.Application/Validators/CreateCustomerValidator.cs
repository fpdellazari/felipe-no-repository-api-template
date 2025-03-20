using FelipeNoRepositoryApiTemplate.Domain.Models.DTOs;
using FluentValidation;

namespace FelipeNoRepositoryApiTemplate.Application.Validators;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerDTO>
{
    public CreateCustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");

        RuleFor(customer => customer.Age)
            .InclusiveBetween(18, 120).WithMessage("A idade deve ser entre 18 e 120 anos.");

        RuleFor(customer => customer.Email)
            .EmailAddress().WithMessage("O e-mail não é válido");
    }
}

