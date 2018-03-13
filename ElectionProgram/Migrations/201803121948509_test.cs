namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidates", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voters", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voters", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Candidates", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Admins", "BirthDate", c => c.DateTime());
        }
    }
}
