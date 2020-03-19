namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrderRelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_UserId");
            DropColumn("dbo.Orders", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ApplicationUser_Id", c => c.String());
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
        }
    }
}
