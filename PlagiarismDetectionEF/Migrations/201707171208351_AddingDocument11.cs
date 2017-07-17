namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDocument11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StopWords", "stopNgramID", "dbo.StopNgrams");
            DropIndex("dbo.StopWords", new[] { "stopNgramID" });
            DropTable("dbo.StopWords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StopWords",
                c => new
                    {
                        stopWordID = c.Int(nullable: false, identity: true),
                        index = c.Int(nullable: false),
                        word = c.String(),
                        stopNgramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stopWordID);
            
            CreateIndex("dbo.StopWords", "stopNgramID");
            AddForeignKey("dbo.StopWords", "stopNgramID", "dbo.StopNgrams", "StopNgramID", cascadeDelete: true);
        }
    }
}
