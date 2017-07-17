namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FromStep1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boundaries",
                c => new
                    {
                        stopNgramID = c.Int(nullable: false),
                        lower = c.Int(nullable: false),
                        upper = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stopNgramID)
                .ForeignKey("dbo.StopNgrams", t => t.stopNgramID)
                .Index(t => t.stopNgramID);
            
            CreateTable(
                "dbo.StopNgrams",
                c => new
                    {
                        StopNgramID = c.Int(nullable: false, identity: true),
                        profileStopWordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StopNgramID)
                .ForeignKey("dbo.ProfileStopWords", t => t.profileStopWordID, cascadeDelete: true)
                .Index(t => t.profileStopWordID);
            
            CreateTable(
                "dbo.ProfileStopWords",
                c => new
                    {
                        ProfileStopWordID = c.Int(nullable: false, identity: true),
                        profileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileStopWordID);
            
            CreateTable(
                "dbo.StopWords",
                c => new
                    {
                        stopWordID = c.Int(nullable: false, identity: true),
                        index = c.Int(nullable: false),
                        word = c.String(),
                        stopNgramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stopWordID)
                .ForeignKey("dbo.StopNgrams", t => t.stopNgramID, cascadeDelete: true)
                .Index(t => t.stopNgramID);
            
            CreateTable(
                "dbo.ListOfWords",
                c => new
                    {
                        listOfWordsID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.listOfWordsID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        wordID = c.Int(nullable: false, identity: true),
                        word = c.String(),
                        listOfWordsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.wordID)
                .ForeignKey("dbo.ListOfWords", t => t.listOfWordsID, cascadeDelete: true)
                .Index(t => t.listOfWordsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "listOfWordsID", "dbo.ListOfWords");
            DropForeignKey("dbo.Boundaries", "stopNgramID", "dbo.StopNgrams");
            DropForeignKey("dbo.StopWords", "stopNgramID", "dbo.StopNgrams");
            DropForeignKey("dbo.StopNgrams", "profileStopWordID", "dbo.ProfileStopWords");
            DropIndex("dbo.Words", new[] { "listOfWordsID" });
            DropIndex("dbo.StopWords", new[] { "stopNgramID" });
            DropIndex("dbo.StopNgrams", new[] { "profileStopWordID" });
            DropIndex("dbo.Boundaries", new[] { "stopNgramID" });
            DropTable("dbo.Words");
            DropTable("dbo.ListOfWords");
            DropTable("dbo.StopWords");
            DropTable("dbo.ProfileStopWords");
            DropTable("dbo.StopNgrams");
            DropTable("dbo.Boundaries");
        }
    }
}
