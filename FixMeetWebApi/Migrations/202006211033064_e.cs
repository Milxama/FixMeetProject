namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferModels", "CustomerFirstName", c => c.String());
            AddColumn("dbo.OfferModels", "CustomerLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferModels", "CustomerLastName");
            DropColumn("dbo.OfferModels", "CustomerFirstName");
        }
    }
}
