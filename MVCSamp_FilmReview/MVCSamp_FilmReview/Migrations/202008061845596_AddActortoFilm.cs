namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActortoFilm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddActors",
                c => new
                    {
                        AddActorId = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddActorId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.ClsFilms", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddActors", "FilmId", "dbo.ClsFilms");
            DropForeignKey("dbo.AddActors", "ActorId", "dbo.Actors");
            DropIndex("dbo.AddActors", new[] { "ActorId" });
            DropIndex("dbo.AddActors", new[] { "FilmId" });
            DropTable("dbo.AddActors");
        }
    }
}
