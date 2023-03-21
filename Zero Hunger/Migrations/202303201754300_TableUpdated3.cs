namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdated3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "NId", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "NId" });
            RenameColumn(table: "dbo.Employees", name: "NId", newName: "NGO_Id");
            AlterColumn("dbo.Employees", "NGO_Id", c => c.Int());
            CreateIndex("dbo.Employees", "NGO_Id");
            AddForeignKey("dbo.Employees", "NGO_Id", "dbo.NGOes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "NGO_Id", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "NGO_Id" });
            AlterColumn("dbo.Employees", "NGO_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "NGO_Id", newName: "NId");
            CreateIndex("dbo.Employees", "NId");
            AddForeignKey("dbo.Employees", "NId", "dbo.NGOes", "Id", cascadeDelete: true);
        }
    }
}
