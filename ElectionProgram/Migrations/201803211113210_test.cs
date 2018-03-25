namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        AccountType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Long(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(),
                        CareerPosition = c.String(),
                        PIC = c.Binary(),
                        Account_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Admin_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.Admin_ID)
                .Index(t => t.Admin_ID);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        NoOfVotes = c.Int(nullable: false),
                        IsApplay = c.Boolean(nullable: false),
                        Name = c.String(),
                        ImagePath = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Long(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(),
                        CareerPosition = c.String(),
                        PIC = c.Binary(),
                        Account_ID = c.Int(),
                        Election_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .ForeignKey("dbo.Elections", t => t.Election_ID)
                .Index(t => t.Account_ID)
                .Index(t => t.Election_ID);
            
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
            
            CreateTable(
                "dbo.Questionaires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Admin_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.Admin_ID)
                .Index(t => t.Admin_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        QuestionaireID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questionaires", t => t.QuestionaireID, cascadeDelete: true)
                .Index(t => t.QuestionaireID);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        answer = c.String(),
                        Question_ID = c.Int(),
                        voter_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .ForeignKey("dbo.Voters", t => t.voter_ID)
                .Index(t => t.Question_ID)
                .Index(t => t.voter_ID);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsVote = c.Boolean(nullable: false),
                        Name = c.String(),
                        ImagePath = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Long(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(),
                        CareerPosition = c.String(),
                        PIC = c.Binary(),
                        Account_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.CandidateVoters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        candidate_id = c.Int(nullable: false),
                        Voter_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.candidate_id, cascadeDelete: true)
                .ForeignKey("dbo.Voters", t => t.Voter_id, cascadeDelete: true)
                .Index(t => t.candidate_id)
                .Index(t => t.Voter_id);
            
            CreateTable(
                "dbo.ElectionPrograms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slogan = c.String(),
                        Program = c.String(),
                        Symbol = c.String(),
                        ProgramStartDate = c.DateTime(nullable: false),
                        ProgramEndDate = c.DateTime(nullable: false),
                        CID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.CID, cascadeDelete: true)
                .Index(t => t.CID);
            
            CreateTable(
                "dbo.Winners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Candidate_ID = c.Int(),
                        Questionaire_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.Candidate_ID)
                .ForeignKey("dbo.Questionaires", t => t.Questionaire_ID)
                .Index(t => t.Candidate_ID)
                .Index(t => t.Questionaire_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Winners", "Questionaire_ID", "dbo.Questionaires");
            DropForeignKey("dbo.Winners", "Candidate_ID", "dbo.Candidates");
            DropForeignKey("dbo.ElectionPrograms", "CID", "dbo.Candidates");
            DropForeignKey("dbo.CandidateVoters", "Voter_id", "dbo.Voters");
            DropForeignKey("dbo.CandidateVoters", "candidate_id", "dbo.Candidates");
            DropForeignKey("dbo.Answers", "voter_ID", "dbo.Voters");
            DropForeignKey("dbo.Voters", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionaireID", "dbo.Questionaires");
            DropForeignKey("dbo.Questionaires", "Admin_ID", "dbo.Admins");
            DropForeignKey("dbo.ElectionSymbols", "election_ID", "dbo.Elections");
            DropForeignKey("dbo.Candidates", "Election_ID", "dbo.Elections");
            DropForeignKey("dbo.Candidates", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Elections", "Admin_ID", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Account_ID", "dbo.Accounts");
            DropIndex("dbo.Winners", new[] { "Questionaire_ID" });
            DropIndex("dbo.Winners", new[] { "Candidate_ID" });
            DropIndex("dbo.ElectionPrograms", new[] { "CID" });
            DropIndex("dbo.CandidateVoters", new[] { "Voter_id" });
            DropIndex("dbo.CandidateVoters", new[] { "candidate_id" });
            DropIndex("dbo.Voters", new[] { "Account_ID" });
            DropIndex("dbo.Answers", new[] { "voter_ID" });
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropIndex("dbo.Questions", new[] { "QuestionaireID" });
            DropIndex("dbo.Questionaires", new[] { "Admin_ID" });
            DropIndex("dbo.ElectionSymbols", new[] { "election_ID" });
            DropIndex("dbo.Candidates", new[] { "Election_ID" });
            DropIndex("dbo.Candidates", new[] { "Account_ID" });
            DropIndex("dbo.Elections", new[] { "Admin_ID" });
            DropIndex("dbo.Admins", new[] { "Account_ID" });
            DropTable("dbo.Winners");
            DropTable("dbo.ElectionPrograms");
            DropTable("dbo.CandidateVoters");
            DropTable("dbo.Voters");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Questionaires");
            DropTable("dbo.ElectionSymbols");
            DropTable("dbo.Candidates");
            DropTable("dbo.Elections");
            DropTable("dbo.Admins");
            DropTable("dbo.Accounts");
        }
    }
}
