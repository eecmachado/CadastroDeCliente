namespace CadastroDeCliente.Application.Interfaces
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handler(TUseCaseResponse response);        
    }
}