﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class ClsFilmContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ClsFilmContext() : base("name=ClsFilmContext")
        {
        }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.ClsFilm> ClsFilms { get; set; }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.AddActor> AddActors { get; set; }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<MVCSamp_FilmReview.Models.CommentReply> CommentReplies { get; set; }
    }
}
