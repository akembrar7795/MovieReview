namespace MovieReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviews : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieReview", newName: "Review");
            AddColumn("dbo.Review", "Reviews", c => c.String(nullable: false));
            DropColumn("dbo.Review", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "Review", c => c.String(nullable: false));
            DropColumn("dbo.Review", "Reviews");
            RenameTable(name: "dbo.Review", newName: "MovieReview");
        }
    }
}
