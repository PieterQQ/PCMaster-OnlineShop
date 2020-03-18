namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Useradded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Orders", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            AlterColumn("dbo.Orders", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Orders", "User_Id");
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
            AddForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
