using CadastroDeCliente.Domain.Entities.Base;

namespace CadastroDeCliente.Domain.Entities
{
    public class ClienteModel : DomainModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }
    }
}
