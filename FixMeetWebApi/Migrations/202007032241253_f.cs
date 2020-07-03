namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingModels",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        CustId = c.String(),
                        SuppId = c.String(),
                        CustFirstName = c.String(),
                        CustLastName = c.String(),
                        SuppFirstName = c.String(),
                        SuppLastName = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RatingModels");
        }
    }
}
