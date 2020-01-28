using CRUD.ApplicationCore.Entities;
using FluentValidation;

namespace CRUD.ApplicationCore.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Nome).Length(0, 30).WithMessage("O nome deve ter no máximo 30 caracteres");
            RuleFor(x => x.CpfCnpj).NotEmpty().WithMessage("O CPF/CNPJ nbão pode estar vazio");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("A data de nascimento não pode estar vazia");
        }
    }
}
