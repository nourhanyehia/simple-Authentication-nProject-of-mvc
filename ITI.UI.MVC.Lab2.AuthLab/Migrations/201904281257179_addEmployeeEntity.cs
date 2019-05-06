namespace ITI.UI.MVC.Lab2.AuthLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        FK_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Department", t => t.FK_DepartmentId, cascadeDelete: true)
                .Index(t => t.FK_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "FK_DepartmentId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
