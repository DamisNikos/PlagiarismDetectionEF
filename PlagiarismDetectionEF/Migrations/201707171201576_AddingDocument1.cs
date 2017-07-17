namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDocument1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ListOfWords", "listOfWordsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListOfWords", "listOfWordsID", c => c.Int(nullable: false));
        }
    }
}
