namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CId = c.Int(nullable: false),
                        EId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collects", t => t.CId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EId, cascadeDelete: true)
                .Index(t => t.CId)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.Collects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false),
                        Quantity = c.String(nullable: false),
                        Preservation_time = c.DateTime(nullable: false),
                        RId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RId, cascadeDelete: true)
                .Index(t => t.RId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 11),
                        NId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NGOes", t => t.NId, cascadeDelete: true)
                .Index(t => t.NId);
            
            CreateTable(
                "dbo.NGOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectDetails", "EId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "NId", "dbo.NGOes");
            DropForeignKey("dbo.CollectDetails", "CId", "dbo.Collects");
            DropForeignKey("dbo.Collects", "RId", "dbo.Restaurants");
            DropIndex("dbo.Employees", new[] { "NId" });
            DropIndex("dbo.Collects", new[] { "RId" });
            DropIndex("dbo.CollectDetails", new[] { "EId" });
            DropIndex("dbo.CollectDetails", new[] { "CId" });
            DropTable("dbo.NGOes");
            DropTable("dbo.Employees");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Collects");
            DropTable("dbo.CollectDetails");
        }
    }
}
