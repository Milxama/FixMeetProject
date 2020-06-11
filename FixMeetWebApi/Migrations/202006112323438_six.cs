namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        OfferID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingModels");
        }
    }
}
