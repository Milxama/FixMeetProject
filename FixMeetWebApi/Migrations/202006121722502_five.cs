namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OfferModels", "RequestID");
            AddForeignKey("dbo.OfferModels", "RequestID", "dbo.RequestModels", "RequestID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferModels", "RequestID", "dbo.RequestModels");
            DropIndex("dbo.OfferModels", new[] { "RequestID" });
        }
    }
}
