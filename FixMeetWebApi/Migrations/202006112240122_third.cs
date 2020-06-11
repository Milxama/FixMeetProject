namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfferModels",
                c => new
                    {
                        OfferID = c.Int(nullable: false, identity: true),
                        OfferDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        UserID = c.String(),
                        RequestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfferID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OfferModels");
        }
    }
}
