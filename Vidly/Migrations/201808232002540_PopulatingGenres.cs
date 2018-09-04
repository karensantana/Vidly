namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Romantic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Mistery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Humor')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
