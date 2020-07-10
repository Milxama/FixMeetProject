namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferModels", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferModels", "PhoneNumber");
        }
    }
}
