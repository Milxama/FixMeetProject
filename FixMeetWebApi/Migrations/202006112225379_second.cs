namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestModels",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.RequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestModels");
        }
    }
}
