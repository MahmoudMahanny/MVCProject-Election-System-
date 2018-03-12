namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class electionFirstUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectionSymbols",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        symbol = c.Binary(),
                        election_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Elections", t => t.election_ID)
                .Index(t => t.election_ID);
            
            AddColumn("dbo.Admins", "PIC", c => c.Binary());
            AddColumn("dbo.Candidates", "PIC", c => c.Binary());
            AddColumn("dbo.Voters", "PIC", c => c.Binary());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ElectionSymbols", "election_ID", "dbo.Elections");
            DropIndex("dbo.ElectionSymbols", new[] { "election_ID" });
            DropColumn("dbo.Voters", "PIC");
            DropColumn("dbo.Candidates", "PIC");
            DropColumn("dbo.Admins", "PIC");
            DropTable("dbo.ElectionSymbols");
        }
    }
}
