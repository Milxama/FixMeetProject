namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "OfferID", c => c.Int(nullable: false));
            AddColumn("dbo.BookingModels", "CustFirstName", c => c.String());
            AddColumn("dbo.BookingModels", "CustLastName", c => c.String());
            AddColumn("dbo.BookingModels", "SuppFirstName", c => c.String());
            AddColumn("dbo.BookingModels", "SuppLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "SuppLastName");
            DropColumn("dbo.BookingModels", "SuppFirstName");
            DropColumn("dbo.BookingModels", "CustLastName");
            DropColumn("dbo.BookingModels", "CustFirstName");
            DropColumn("dbo.BookingModels", "OfferID");
        }
    }
}
