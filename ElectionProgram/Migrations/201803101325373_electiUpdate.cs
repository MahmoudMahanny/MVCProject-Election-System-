namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class electiUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "NID", c => c.Long(nullable: false));
            AlterColumn("dbo.Candidates", "NID", c => c.Long(nullable: false));
            AlterColumn("dbo.Voters", "NID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voters", "NID", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "NID", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "NID", c => c.Int(nullable: false));
        }
    }
}
