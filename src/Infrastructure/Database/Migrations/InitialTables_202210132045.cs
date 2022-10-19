using FluentMigrator;

namespace Infrastructure.Database.Migrations
{
    [Migration(202210132045)]
    public class InitialTables_202210132045 : Migration
    {
        public override void Up()
        {
            Create.Table("CUSTOMER")
                .WithColumn("CUSTOMER_ID").AsString().PrimaryKey()
                .WithColumn("NAME").AsString().NotNullable()
                .WithColumn("COUNTRY").AsString().NotNullable();

            Create.Table("METERING_POINT")
                .WithColumn("METERING_POINT_ID").AsString().PrimaryKey()
                .WithColumn("NAME").AsString().NotNullable()
                .WithColumn("POWER_ZONE").AsString().NotNullable()
                .WithColumn("STREET").AsString().NotNullable()
                .WithColumn("ZIP").AsString().NotNullable()
                .WithColumn("CUSTOMER_ID").AsString()
                .ForeignKey("METERING_POINT_CUSTOMER_ID", "CUSTOMER", "CUSTOMER_ID");
        }

        public override void Down()
        {
            Delete.Table("Customer");
        }
    }
}
