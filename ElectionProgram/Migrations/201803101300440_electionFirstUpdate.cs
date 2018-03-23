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
            
            AddColumn("dbo.Admins", "ImagePath", c => c.Binary());
            AddColumn("dbo.Candidates", "ImagePath", c => c.Binary());
            AddColumn("dbo.Voters", "ImagePath", c => c.Binary());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ElectionSymbols", "election_ID", "dbo.Elections");
            DropIndex("dbo.ElectionSymbols", new[] { "election_ID" });
            DropColumn("dbo.Voters", "ImagePath");
            DropColumn("dbo.Candidates", "ImagePath");
            DropColumn("dbo.Admins", "ImagePath");
            DropTable("dbo.ElectionSymbols");
        }
    }
}
