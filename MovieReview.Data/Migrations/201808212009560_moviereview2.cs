namespace MovieReview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviereview2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        MovieName = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movie");
        }
    }
}
