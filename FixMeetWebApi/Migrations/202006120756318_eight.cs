namespace FixMeetWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Radius", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Radius");
            DropColumn("dbo.AspNetUsers", "Category");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
