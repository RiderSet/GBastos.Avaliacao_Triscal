using CRUD.ApplicationCore.Entities;
using FluentValidation;

namespace CRUD.ApplicationCore.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(x => x.Logradouro).NotEmpty().Length(0, 50).WithMessage("O Logradouro é obrigatório e deve ter no máximo 50 caracteres");
            RuleFor(x => x.Bairro).NotEmpty().Length(0, 40).WithMessage("O nome do Bairro é obrigatório e deve ter no máximo 40 caracteres");
            RuleFor(x => x.Cidade).NotEmpty().Length(0, 40).WithMessage("O nome da cidade é obrigatória e deve ter no máximo 40 caracteres");
            RuleFor(x => x.Estado).NotEmpty().Length(0, 40).WithMessage("O nome do Estado é obrigatório e deve ter no máximo 40 caracteres");
        }
    }
}
