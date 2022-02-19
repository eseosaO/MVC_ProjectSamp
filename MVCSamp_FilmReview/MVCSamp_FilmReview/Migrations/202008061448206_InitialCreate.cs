namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClsFilms",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmName = c.String(nullable: false),
                        Description = c.String(maxLength: 400),
                        DirectorId = c.Int(nullable: false),
                        GenreName = c.String(),
                        ReleaseDate = c.String(nullable: false),
                        AverageScore = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .Index(t => t.DirectorId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        ReviewId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        Content = c.String(),
                        UserScore = c.Single(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId)
                .Index(t => t.ActorId)
                .Index(t => t.DirectorId);
            
            CreateTable(
                "dbo.CommentReplies",
                c => new
                    {
                        CommentReplyId = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        AuthorId = c.String(),
                        Content = c.String(),
                        ReviewId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentReplyId)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        DateofBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ReviewTitle = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        ReviewScore = c.Int(nullable: false),
                        ClsFilm_FilmId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.ClsFilms", t => t.ClsFilm_FilmId)
                .Index(t => t.ClsFilm_FilmId);
            
            CreateTable(
                "dbo.ActorClsFilms",
                c => new
                    {
                        Actor_ActorId = c.Int(nullable: false),
                        ClsFilm_FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_ActorId, t.ClsFilm_FilmId })
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId, cascadeDelete: true)
                .ForeignKey("dbo.ClsFilms", t => t.ClsFilm_FilmId, cascadeDelete: true)
                .Index(t => t.Actor_ActorId)
                .Index(t => t.ClsFilm_FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ClsFilm_FilmId", "dbo.ClsFilms");
            DropForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.ClsFilms", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.Comments", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.ActorClsFilms", "ClsFilm_FilmId", "dbo.ClsFilms");
            DropForeignKey("dbo.ActorClsFilms", "Actor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.Comments", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.CommentReplies", "CommentId", "dbo.Comments");
            DropIndex("dbo.ActorClsFilms", new[] { "ClsFilm_FilmId" });
            DropIndex("dbo.ActorClsFilms", new[] { "Actor_ActorId" });
            DropIndex("dbo.Reviews", new[] { "ClsFilm_FilmId" });
            DropIndex("dbo.CommentReplies", new[] { "CommentId" });
            DropIndex("dbo.Comments", new[] { "DirectorId" });
            DropIndex("dbo.Comments", new[] { "ActorId" });
            DropIndex("dbo.Comments", new[] { "ReviewId" });
            DropIndex("dbo.ClsFilms", new[] { "DirectorId" });
            DropTable("dbo.ActorClsFilms");
            DropTable("dbo.Reviews");
            DropTable("dbo.Directors");
            DropTable("dbo.CommentReplies");
            DropTable("dbo.Comments");
            DropTable("dbo.Actors");
            DropTable("dbo.ClsFilms");
        }
    }
}
