namespace CandidateApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        QualificationType = c.String(),
                        QualificationName = c.String(),
                        DateStarted = c.DateTime(),
                        DateCompleted = c.DateTime(),
                        CandidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Qualifications", new[] { "CandidateId" });
            DropTable("dbo.Qualifications");
            DropTable("dbo.Candidates");
        }
    }
}
