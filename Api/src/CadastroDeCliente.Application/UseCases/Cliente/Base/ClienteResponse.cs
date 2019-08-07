using System.Collections.Generic;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base
{
    public class ClienteResponse : UseCaseResponseMessage
    {
        public ClienteResponse() { }

        public ClienteResponse(string error) : base(error) { }

        public ClienteResponse(IEnumerable<string> errors) : base(errors) { }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }
    }
}
