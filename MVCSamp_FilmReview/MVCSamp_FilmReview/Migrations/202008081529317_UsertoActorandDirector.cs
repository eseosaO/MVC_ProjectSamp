namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsertoActorandDirector : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "User", c => c.String());
            AddColumn("dbo.Directors", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "User");
            DropColumn("dbo.Actors", "User");
        }
    }
}
