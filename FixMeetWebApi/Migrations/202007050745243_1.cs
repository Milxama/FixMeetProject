namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NegotiationChatModels",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        ChatDate = c.DateTime(nullable: false),
                        ChatText = c.String(nullable: false),
                        OfferID = c.Int(nullable: false),
                        CustId = c.String(),
                        SuppId = c.String(),
                    })
                .PrimaryKey(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NegotiationChatModels");
        }
    }
}
