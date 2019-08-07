using CadastroDeCliente.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base
{
    public class ExcluirClienteRequest : IUseCaseRequest<ClienteResponse>
    {
        [Required]
        public int Id { get; set; }
    }
}
