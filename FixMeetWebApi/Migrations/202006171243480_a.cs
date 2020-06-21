namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "CustId", c => c.String(nullable: false));
            AddColumn("dbo.BookingModels", "SuppId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "SuppId");
            DropColumn("dbo.BookingModels", "CustId");
        }
    }
}
