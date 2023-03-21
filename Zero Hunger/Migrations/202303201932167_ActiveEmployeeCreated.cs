﻿namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActiveEmployeeCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiveEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActiveEmployees");
        }
    }
}
