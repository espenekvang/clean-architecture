using FluentMigrator;

namespace Infrastructure.Database.Migrations
{
    [Migration(202210132045)]
    public class InitialTables_202210132045 : Migration
    {
        public override void Up()
        {
            Create.Table("Customer")
                .WithColumn("Id").AsString().PrimaryKey()
                .WithColumn("Name").AsString()
                .WithColumn("Country").AsString();
        }

        public override void Down()
        {
            Delete.Table("Customer");
        }
    }
}
