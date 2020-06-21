namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookingModels", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "Description", c => c.String(nullable: false));
        }
    }
}
