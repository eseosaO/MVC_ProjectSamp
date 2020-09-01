namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserScoretyp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserScore", c => c.Single(nullable: false));
        }
    }
}
