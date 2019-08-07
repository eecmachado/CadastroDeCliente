using CadastroDeCliente.Api.Response;
using CadastroDeCliente.Application;
using CadastroDeCliente.Application.Interfaces;
using CadastroDeCliente.Application.UseCases.Carro.Base;
using System.Threading.Tasks;

namespace CadastroDeCliente.Test
{
    public class CarroBuilder : UseCaseResponseMessage
    {
        public Presenter RetornoInvalido()
        {
            return new Presenter();
        }

        public Task RetornoValido(IOutputPort<CarroResponse> outputPort)
        {
            var teste = new CarroResponse();
            Task.FromResult(outputPort.Handler(teste));
        }
    }
}
