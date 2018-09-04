namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingValuesofBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday='27 de Octubre 1990' WHERE Id=03");
        }
        
        public override void Down()
        {
        }
    }
}
