namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        documentID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        context = c.Binary(),
                    })
                .PrimaryKey(t => t.documentID);
            
            CreateTable(
                "dbo.ProfileStopWords",
                c => new
                    {
                        ProfileStopWordID = c.Int(nullable: false, identity: true),
                        profileType = c.Int(nullable: false),
                        documentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileStopWordID)
                .ForeignKey("dbo.Documents", t => t.documentID, cascadeDelete: true)
                .Index(t => t.documentID);
            
            CreateTable(
                "dbo.StopNgrams",
                c => new
                    {
                        StopNgramID = c.Int(nullable: false, identity: true),
                        stopWordsInString = c.String(nullable: false),
                        lower = c.Int(nullable: false),
                        upper = c.Int(nullable: false),
                        profileStopWordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StopNgramID)
                .ForeignKey("dbo.ProfileStopWords", t => t.profileStopWordID, cascadeDelete: true)
                .Index(t => t.profileStopWordID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        wordID = c.Int(nullable: false, identity: true),
                        word = c.String(),
                        documentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.wordID)
                .ForeignKey("dbo.Documents", t => t.documentID, cascadeDelete: true)
                .Index(t => t.documentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "documentID", "dbo.Documents");
            DropForeignKey("dbo.StopNgrams", "profileStopWordID", "dbo.ProfileStopWords");
            DropForeignKey("dbo.ProfileStopWords", "documentID", "dbo.Documents");
            DropIndex("dbo.Words", new[] { "documentID" });
            DropIndex("dbo.StopNgrams", new[] { "profileStopWordID" });
            DropIndex("dbo.ProfileStopWords", new[] { "documentID" });
            DropTable("dbo.Words");
            DropTable("dbo.StopNgrams");
            DropTable("dbo.ProfileStopWords");
            DropTable("dbo.Documents");
        }
    }
}
