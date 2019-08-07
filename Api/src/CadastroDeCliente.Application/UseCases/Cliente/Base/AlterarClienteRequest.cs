using CadastroDeCliente.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base
{
    public class AlterarClienteRequest: IUseCaseRequest<ClienteResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
