namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsertoClsFilm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClsFilms", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClsFilms", "User");
        }
    }
}
