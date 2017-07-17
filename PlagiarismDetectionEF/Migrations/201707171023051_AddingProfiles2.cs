namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProfiles2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StopNgrams", "stopWordsInString", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StopNgrams", "stopWordsInString");
        }
    }
}
