namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActortoModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ActorClsFilms", newName: "ClsFilmActors");
            DropPrimaryKey("dbo.ClsFilmActors");
            AddPrimaryKey("dbo.ClsFilmActors", new[] { "ClsFilm_FilmId", "Actor_ActorId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ClsFilmActors");
            AddPrimaryKey("dbo.ClsFilmActors", new[] { "Actor_ActorId", "ClsFilm_FilmId" });
            RenameTable(name: "dbo.ClsFilmActors", newName: "ActorClsFilms");
        }
    }
}
