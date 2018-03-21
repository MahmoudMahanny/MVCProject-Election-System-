namespace ElectionProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answertype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "answer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "answer", c => c.String());
        }
    }
}
