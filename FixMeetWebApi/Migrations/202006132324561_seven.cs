namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "RequestID", c => c.Int(nullable: false));
            DropColumn("dbo.BookingModels", "OfferID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "OfferID", c => c.Int(nullable: false));
            DropColumn("dbo.BookingModels", "RequestID");
        }
    }
}
