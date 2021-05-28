namespace Vidlet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Suspense')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
