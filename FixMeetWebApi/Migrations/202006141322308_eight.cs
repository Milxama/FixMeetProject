namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestModels", "CustomerFirstName", c => c.String());
            AddColumn("dbo.RequestModels", "CustomerLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestModels", "CustomerLastName");
            DropColumn("dbo.RequestModels", "CustomerFirstName");
        }
    }
}
