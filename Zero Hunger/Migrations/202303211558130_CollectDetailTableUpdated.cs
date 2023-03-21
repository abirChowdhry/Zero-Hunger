namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectDetailTableUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectDetails", "CId", "dbo.Collects");
            DropForeignKey("dbo.CollectDetails", "EId", "dbo.Employees");
            DropIndex("dbo.CollectDetails", new[] { "CId" });
            DropIndex("dbo.CollectDetails", new[] { "EId" });
            RenameColumn(table: "dbo.CollectDetails", name: "CId", newName: "Collect_Id");
            RenameColumn(table: "dbo.CollectDetails", name: "EId", newName: "Employee_Id");
            AddColumn("dbo.CollectDetails", "RestaurantName", c => c.String(nullable: false));
            AddColumn("dbo.CollectDetails", "Item", c => c.String(nullable: false));
            AddColumn("dbo.CollectDetails", "Quantity", c => c.String(nullable: false));
            AddColumn("dbo.CollectDetails", "Preservation_time", c => c.String(nullable: false));
            AddColumn("dbo.CollectDetails", "EmployeeName", c => c.String(nullable: false));
            AlterColumn("dbo.CollectDetails", "Collect_Id", c => c.Int());
            AlterColumn("dbo.CollectDetails", "Employee_Id", c => c.Int());
            CreateIndex("dbo.CollectDetails", "Collect_Id");
            CreateIndex("dbo.CollectDetails", "Employee_Id");
            AddForeignKey("dbo.CollectDetails", "Collect_Id", "dbo.Collects", "Id");
            AddForeignKey("dbo.CollectDetails", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectDetails", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CollectDetails", "Collect_Id", "dbo.Collects");
            DropIndex("dbo.CollectDetails", new[] { "Employee_Id" });
            DropIndex("dbo.CollectDetails", new[] { "Collect_Id" });
            AlterColumn("dbo.CollectDetails", "Employee_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CollectDetails", "Collect_Id", c => c.Int(nullable: false));
            DropColumn("dbo.CollectDetails", "EmployeeName");
            DropColumn("dbo.CollectDetails", "Preservation_time");
            DropColumn("dbo.CollectDetails", "Quantity");
            DropColumn("dbo.CollectDetails", "Item");
            DropColumn("dbo.CollectDetails", "RestaurantName");
            RenameColumn(table: "dbo.CollectDetails", name: "Employee_Id", newName: "EId");
            RenameColumn(table: "dbo.CollectDetails", name: "Collect_Id", newName: "CId");
            CreateIndex("dbo.CollectDetails", "EId");
            CreateIndex("dbo.CollectDetails", "CId");
            AddForeignKey("dbo.CollectDetails", "EId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CollectDetails", "CId", "dbo.Collects", "Id", cascadeDelete: true);
        }
    }
}
