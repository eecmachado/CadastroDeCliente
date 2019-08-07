using FluentMigrator;
using CadastroDeCliente.Infra.Migrations.Base;

namespace CadastroDeCliente.Infra.Migrations
{
    [MigrationBase(1, "emmanuel.machado")]
    public class Baseline : Migration
    {
        public override void Up()
        {
            Create.Table("Cliente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Nome").AsAnsiString(30).NotNullable()
                .WithColumn("Sobrenome").AsAnsiString(50).NotNullable()
                .WithColumn("Cpf").AsAnsiString(11).NotNullable()
                .WithColumn("Email").AsAnsiString(50).NotNullable();

            Create.Index("Idx_Cliente_Cpf").OnTable("Cliente")
                .OnColumn("Cpf").Ascending()
                .WithOptions().Unique();
        }

        public override void Down()
        {
            Delete.Table("Cliente");
        }
    }

    [Migration(0)]
    public class Setup : Migration
    {
        public override void Up()
        {

        }

        public override void Down()
        {

        }
    }
}
