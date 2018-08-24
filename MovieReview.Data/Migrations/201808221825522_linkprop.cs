namespace MovieReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "MovieID", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "MovieID");
            AddForeignKey("dbo.Review", "MovieID", "dbo.Movie", "MovieID", cascadeDelete: true);
            DropColumn("dbo.Review", "Genre");
            DropColumn("dbo.Review", "Title");
            DropColumn("dbo.Review", "Director");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "Director", c => c.String(nullable: false));
            AddColumn("dbo.Review", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Review", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.Review", "MovieID", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "MovieID" });
            DropColumn("dbo.Review", "MovieID");
        }
    }
}
