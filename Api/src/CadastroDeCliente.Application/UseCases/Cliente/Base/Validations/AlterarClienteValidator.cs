using FluentValidation;
using CadastroDeCliente.Application.Resources;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base.Validations
{
    public class AlterarClienteValidator : AbstractValidator<AlterarClienteRequest>
    {
        public AlterarClienteValidator()
        {
            ValidateId();
            ValidateNome();
            ValidateSobrenome();
            ValidateCpf();
        }

        protected void ValidateId()
        {
            RuleFor(r => r.Id)
                .NotEqual(0)
                .WithMessage(string.Format(Mensagens.Obrigatorio, "Id"));
        }

        protected void ValidateNome()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage(string.Format(Mensagens.Obrigatorio, "Nome"))
                .Length(1, 30)
                .WithMessage(string.Format(Mensagens.IntervaloCaracteres, "Nome", "1", "30"));
        }

        protected void ValidateSobrenome()
        {
            RuleFor(r => r.Sobrenome)
                .NotEmpty()
                .WithMessage(string.Format(Mensagens.Obrigatorio, "Sobrenome"))
                .Length(1, 50)
                .WithMessage(string.Format(Mensagens.IntervaloCaracteres, "Sobrenome", "1", "50"));
        }

        protected void ValidateCpf()
        {
            RuleFor(r => r.Cpf)
                .NotEmpty()
                .WithMessage(string.Format(Mensagens.Obrigatorio, "Cpf"))
                .Length(11, 11)
                .WithMessage(string.Format(Mensagens.IntervaloCaracteres, "Cpf", "11", "11"));
        }
    }
}
