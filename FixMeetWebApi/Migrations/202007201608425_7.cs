namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Radius");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Radius", c => c.String());
        }
    }
}
