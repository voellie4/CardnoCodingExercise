namespace CandidateApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetStringLengthsAndUniqueEmailPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "FirstName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Candidates", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Candidates", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Candidates", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Qualifications", "QualificationType", c => c.String(maxLength: 30));
            CreateIndex("dbo.Candidates", "PhoneNumber", unique: true);
            CreateIndex("dbo.Candidates", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Candidates", new[] { "Email" });
            DropIndex("dbo.Candidates", new[] { "PhoneNumber" });
            AlterColumn("dbo.Qualifications", "QualificationType", c => c.String());
            AlterColumn("dbo.Candidates", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "FirstName", c => c.String(nullable: false));
        }
    }
}
