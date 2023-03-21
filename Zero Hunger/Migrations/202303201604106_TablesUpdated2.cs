namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesUpdated2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collects", "Preservation_time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collects", "Preservation_time", c => c.DateTime(nullable: false));
        }
    }
}
