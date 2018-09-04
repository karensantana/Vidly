namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToDateAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
        }
    }
}
