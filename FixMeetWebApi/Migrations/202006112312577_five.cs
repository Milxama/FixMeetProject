namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestModels", "IsOpen", c => c.Boolean(nullable: false));
            DropColumn("dbo.RequestModels", "OpenOrClosed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestModels", "OpenOrClosed", c => c.Boolean(nullable: false));
            DropColumn("dbo.RequestModels", "IsOpen");
        }
    }
}
