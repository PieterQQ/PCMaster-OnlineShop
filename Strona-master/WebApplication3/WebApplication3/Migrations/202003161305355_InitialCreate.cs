namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PodzespolId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Podzespols", t => t.PodzespolId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PodzespolId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 150),
                        LastName = c.String(maxLength: 150),
                        Address = c.String(),
                        CodeAndCity = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        TotalPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Podzespols",
                c => new
                    {
                        PodzespolId = c.Int(nullable: false, identity: true),
                        PodzespolyId = c.Int(nullable: false),
                        NazwaPodzespolu = c.String(),
                        Producent = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        ConvertFileName = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsBestseller = c.Boolean(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PodzespolId)
                .ForeignKey("dbo.podzespolies", t => t.PodzespolyId, cascadeDelete: true)
                .Index(t => t.PodzespolyId);
            
            CreateTable(
                "dbo.podzespolies",
                c => new
                    {
                        PodzespolyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.PodzespolyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "PodzespolId", "dbo.Podzespols");
            DropForeignKey("dbo.Podzespols", "PodzespolyId", "dbo.podzespolies");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.Podzespols", new[] { "PodzespolyId" });
            DropIndex("dbo.OrderItems", new[] { "PodzespolId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.podzespolies");
            DropTable("dbo.Podzespols");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
