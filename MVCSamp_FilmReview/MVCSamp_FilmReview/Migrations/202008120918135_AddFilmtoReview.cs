namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilmtoReview : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reviews", name: "ClsFilm_FilmId", newName: "FilmForReview_FilmId");
            RenameIndex(table: "dbo.Reviews", name: "IX_ClsFilm_FilmId", newName: "IX_FilmForReview_FilmId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reviews", name: "IX_FilmForReview_FilmId", newName: "IX_ClsFilm_FilmId");
            RenameColumn(table: "dbo.Reviews", name: "FilmForReview_FilmId", newName: "ClsFilm_FilmId");
        }
    }
}
