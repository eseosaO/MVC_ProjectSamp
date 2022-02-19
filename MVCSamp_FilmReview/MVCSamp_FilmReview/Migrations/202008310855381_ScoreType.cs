namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "ReviewScore", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "ReviewScore", c => c.Int(nullable: false));
        }
    }
}
