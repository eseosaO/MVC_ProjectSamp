namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedActor1db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "FirstName", c => c.String());
            AlterColumn("dbo.Actors", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "FirstName", c => c.String(nullable: false));
        }
    }
}
