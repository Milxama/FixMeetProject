namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingModels", "CustId", c => c.String());
            AlterColumn("dbo.BookingModels", "SuppId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingModels", "SuppId", c => c.String(nullable: false));
            AlterColumn("dbo.BookingModels", "CustId", c => c.String(nullable: false));
        }
    }
}
