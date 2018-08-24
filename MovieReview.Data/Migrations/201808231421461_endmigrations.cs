namespace MovieReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endmigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "MovieID", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "MovieID" });
            AddColumn("dbo.Review", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Review", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Review", "UserName");
            CreateIndex("dbo.Review", "MovieID");
            AddForeignKey("dbo.Review", "MovieID", "dbo.Movie", "MovieID", cascadeDelete: true);
        }
    }
}
