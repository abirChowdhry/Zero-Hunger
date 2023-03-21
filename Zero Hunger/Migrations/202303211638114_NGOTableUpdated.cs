namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NGOTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NGOes", "Username", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.NGOes", "Password", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.NGOes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NGOes", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.NGOes", "Password");
            DropColumn("dbo.NGOes", "Username");
        }
    }
}
