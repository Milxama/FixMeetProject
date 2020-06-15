namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferModels", "SupplierFirstName", c => c.String());
            AddColumn("dbo.OfferModels", "SupplierLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferModels", "SupplierLastName");
            DropColumn("dbo.OfferModels", "SupplierFirstName");
        }
    }
}
