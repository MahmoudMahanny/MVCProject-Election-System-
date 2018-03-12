namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                        CareerPosition = c.String(),
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
                        ID = c.Int(nullable: false, identity: true),
                        NoOfVotes = c.Int(nullable: false),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                        CareerPosition = c.String(),
                        Account_ID = c.Int(),
                        Election_ID = c.Int(),
                        ElectionProgram_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .ForeignKey("dbo.Elections", t => t.Election_ID)
                .ForeignKey("dbo.ElectionPrograms", t => t.ElectionProgram_ID)
                .Index(t => t.Account_ID)
                .Index(t => t.Election_ID)
                .Index(t => t.ElectionProgram_ID);
            
            CreateTable(
                "dbo.ElectionPrograms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slogan = c.String(),
                        Program = c.String(),
                        Symbol = c.Binary(),
                        ProgramStartDate = c.DateTime(nullable: false),
                        ProgramEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Questionaire_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questionaires", t => t.Questionaire_ID)
                .Index(t => t.Questionaire_ID);
            
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
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        NID = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                        CareerPosition = c.String(),
                        Account_ID = c.Int(),
                        CandidateVoter_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .ForeignKey("dbo.CandidateVoters", t => t.CandidateVoter_ID)
                .Index(t => t.Account_ID)
                .Index(t => t.CandidateVoter_ID);
            
            CreateTable(
                "dbo.CandidateVoters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Candidate_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.Candidate_ID)
                .Index(t => t.Candidate_ID);
            
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
            DropForeignKey("dbo.Voters", "CandidateVoter_ID", "dbo.CandidateVoters");
            DropForeignKey("dbo.CandidateVoters", "Candidate_ID", "dbo.Candidates");
            DropForeignKey("dbo.Answers", "voter_ID", "dbo.Voters");
            DropForeignKey("dbo.Voters", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Questionaire_ID", "dbo.Questionaires");
            DropForeignKey("dbo.Questionaires", "Admin_ID", "dbo.Admins");
            DropForeignKey("dbo.Candidates", "ElectionProgram_ID", "dbo.ElectionPrograms");
            DropForeignKey("dbo.Candidates", "Election_ID", "dbo.Elections");
            DropForeignKey("dbo.Candidates", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Elections", "Admin_ID", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Account_ID", "dbo.Accounts");
            DropIndex("dbo.Winners", new[] { "Questionaire_ID" });
            DropIndex("dbo.Winners", new[] { "Candidate_ID" });
            DropIndex("dbo.CandidateVoters", new[] { "Candidate_ID" });
            DropIndex("dbo.Voters", new[] { "CandidateVoter_ID" });
            DropIndex("dbo.Voters", new[] { "Account_ID" });
            DropIndex("dbo.Answers", new[] { "voter_ID" });
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropIndex("dbo.Questions", new[] { "Questionaire_ID" });
            DropIndex("dbo.Questionaires", new[] { "Admin_ID" });
            DropIndex("dbo.Candidates", new[] { "ElectionProgram_ID" });
            DropIndex("dbo.Candidates", new[] { "Election_ID" });
            DropIndex("dbo.Candidates", new[] { "Account_ID" });
            DropIndex("dbo.Elections", new[] { "Admin_ID" });
            DropIndex("dbo.Admins", new[] { "Account_ID" });
            DropTable("dbo.Winners");
            DropTable("dbo.CandidateVoters");
            DropTable("dbo.Voters");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Questionaires");
            DropTable("dbo.ElectionPrograms");
            DropTable("dbo.Candidates");
            DropTable("dbo.Elections");
            DropTable("dbo.Admins");
            DropTable("dbo.Accounts");
        }
    }
}
