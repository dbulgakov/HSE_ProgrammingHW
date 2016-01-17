namespace EmployeesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Positions", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Positions", "Salary", c => c.Int(nullable: false));
        }
    }
}
