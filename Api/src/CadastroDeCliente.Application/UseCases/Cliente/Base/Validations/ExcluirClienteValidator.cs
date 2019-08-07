using FluentValidation;
using CadastroDeCliente.Application.Resources;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base.Validations
{
    public class ExcluirClienteValidator : AbstractValidator<ExcluirClienteRequest>
    {
        public ExcluirClienteValidator()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(r => r.Id)
                .NotEqual(0)
                .WithMessage(string.Format(Mensagens.Obrigatorio, "Id"));
        }
    }
}
