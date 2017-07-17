namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDocument : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "listOfWordsID", "dbo.ListOfWords");
            DropIndex("dbo.Words", new[] { "listOfWordsID" });
            DropPrimaryKey("dbo.ListOfWords");
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        documentID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        context = c.Binary(),
                    })
                .PrimaryKey(t => t.documentID);
            
            AddColumn("dbo.ProfileStopWords", "documentID", c => c.Int(nullable: false));
            AddColumn("dbo.ListOfWords", "documentID", c => c.Int(nullable: false));
            AddColumn("dbo.Words", "listOfWords_documentID", c => c.Int());
            AlterColumn("dbo.ListOfWords", "listOfWordsID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ListOfWords", "documentID");
            CreateIndex("dbo.ProfileStopWords", "documentID");
            CreateIndex("dbo.ListOfWords", "documentID");
            CreateIndex("dbo.Words", "listOfWords_documentID");
            AddForeignKey("dbo.ProfileStopWords", "documentID", "dbo.Documents", "documentID", cascadeDelete: true);
            AddForeignKey("dbo.ListOfWords", "documentID", "dbo.Documents", "documentID");
            AddForeignKey("dbo.Words", "listOfWords_documentID", "dbo.ListOfWords", "documentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "listOfWords_documentID", "dbo.ListOfWords");
            DropForeignKey("dbo.ListOfWords", "documentID", "dbo.Documents");
            DropForeignKey("dbo.ProfileStopWords", "documentID", "dbo.Documents");
            DropIndex("dbo.Words", new[] { "listOfWords_documentID" });
            DropIndex("dbo.ListOfWords", new[] { "documentID" });
            DropIndex("dbo.ProfileStopWords", new[] { "documentID" });
            DropPrimaryKey("dbo.ListOfWords");
            AlterColumn("dbo.ListOfWords", "listOfWordsID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Words", "listOfWords_documentID");
            DropColumn("dbo.ListOfWords", "documentID");
            DropColumn("dbo.ProfileStopWords", "documentID");
            DropTable("dbo.Documents");
            AddPrimaryKey("dbo.ListOfWords", "listOfWordsID");
            CreateIndex("dbo.Words", "listOfWordsID");
            AddForeignKey("dbo.Words", "listOfWordsID", "dbo.ListOfWords", "listOfWordsID", cascadeDelete: true);
        }
    }
}
