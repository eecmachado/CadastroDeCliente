using CadastroDeCliente.Infra.Data.NHibernateDataAccess.DataModels;

namespace CadastroDeCliente.Infra.Data.NHibernateDataAccess.Mappings.Cliente
{
    public class ClienteMap : MapBase<ClienteData>
    {
        public ClienteMap()
        {
            CreateIdColumn("Cliente", "Id");
            Map(m => m.Nome, "Nome");
            Map(m => m.Sobrenome, "Sobrenome");
            Map(m => m.Cpf, "Cpf");
            Map(m => m.Email, "Email");
        }

    }
}
