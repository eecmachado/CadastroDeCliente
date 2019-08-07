using FluentValidation;
using CadastroDeCliente.Application.Resources;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base.Validations
{
    public class InserirClienteValidator : AbstractValidator<InserirClienteRequest>
    {
        public InserirClienteValidator()
        {
            ValidateNome();
            ValidateSobrenome();
            ValidateCpf();
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
