namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldsToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "ReleasedDate", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "ReleasedDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
