namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class electionSecondUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Admins", "Phone", c => c.Int());
            AlterColumn("dbo.Candidates", "NoOfVotes", c => c.Int());
            AlterColumn("dbo.Candidates", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Candidates", "Phone", c => c.Int());
            AlterColumn("dbo.Voters", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Voters", "Phone", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voters", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Voters", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidates", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidates", "NoOfVotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
