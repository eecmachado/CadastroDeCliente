using CrudClean.Api.Response;
using CrudClean.Application;
using CrudClean.Application.Interfaces;
using CrudClean.Application.UseCases.Carro.Base;
using System.Threading.Tasks;

namespace CrudClean.Test
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
