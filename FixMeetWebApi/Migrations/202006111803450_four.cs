namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class four : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StudId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentModels");
        }
    }
}
