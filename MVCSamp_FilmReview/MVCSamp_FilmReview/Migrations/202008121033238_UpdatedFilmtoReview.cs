namespace MVCSamp_FilmReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFilmtoReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "FilmForReview_FilmId", "dbo.ClsFilms");
            DropIndex("dbo.Reviews", new[] { "FilmForReview_FilmId" });
            RenameColumn(table: "dbo.Reviews", name: "FilmForReview_FilmId", newName: "FilmId");
            AlterColumn("dbo.Reviews", "FilmId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "FilmId");
            AddForeignKey("dbo.Reviews", "FilmId", "dbo.ClsFilms", "FilmId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.ClsFilms");
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            AlterColumn("dbo.Reviews", "FilmId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "FilmId", newName: "FilmForReview_FilmId");
            CreateIndex("dbo.Reviews", "FilmForReview_FilmId");
            AddForeignKey("dbo.Reviews", "FilmForReview_FilmId", "dbo.ClsFilms", "FilmId");
        }
    }
}
