namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDescriptionFilm2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClsFilms", "Description", c => c.String(maxLength: 800));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClsFilms", "Description", c => c.String(maxLength: 400));
        }
    }
}
