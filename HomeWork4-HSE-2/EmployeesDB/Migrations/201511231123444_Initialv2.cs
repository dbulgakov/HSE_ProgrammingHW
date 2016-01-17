namespace EmployeesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Position_Id = c.Int(nullable: false),
                        Supervisor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Supervisor_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Supervisor_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Supervisor_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Position_Id", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "Supervisor_Id" });
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
        }
    }
}
