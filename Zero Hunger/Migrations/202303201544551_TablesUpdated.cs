namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Collects", "RId", "dbo.Restaurants");
            DropIndex("dbo.Collects", new[] { "RId" });
            AddColumn("dbo.Collects", "RestaurantName", c => c.String(nullable: false));
            DropColumn("dbo.Collects", "RId");
            DropTable("dbo.Restaurants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Collects", "RId", c => c.Int(nullable: false));
            DropColumn("dbo.Collects", "RestaurantName");
            CreateIndex("dbo.Collects", "RId");
            AddForeignKey("dbo.Collects", "RId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
