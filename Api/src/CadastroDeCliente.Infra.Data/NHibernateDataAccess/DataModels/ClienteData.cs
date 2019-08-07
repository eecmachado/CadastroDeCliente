namespace CadastroDeCliente.Infra.Data.NHibernateDataAccess.DataModels
{
    public class ClienteData : DataModel
    {
        public virtual string Nome { get; set; }

        public virtual string Sobrenome { get; set; }

        public virtual string Cpf { get; set; }

        public virtual string Email { get; set; }
    }
}
