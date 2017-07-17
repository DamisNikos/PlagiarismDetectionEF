namespace PlagiarismDetectionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileStopWords",
                c => new
                    {
                        ProfileStopWordID = c.Int(nullable: false, identity: true),
                        profileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileStopWordID);
            
            AddColumn("dbo.StopNgrams", "profileStopWordID", c => c.Int(nullable: false));
            CreateIndex("dbo.StopNgrams", "profileStopWordID");
            AddForeignKey("dbo.StopNgrams", "profileStopWordID", "dbo.ProfileStopWords", "ProfileStopWordID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StopNgrams", "profileStopWordID", "dbo.ProfileStopWords");
            DropIndex("dbo.StopNgrams", new[] { "profileStopWordID" });
            DropColumn("dbo.StopNgrams", "profileStopWordID");
            DropTable("dbo.ProfileStopWords");
        }
    }
}
