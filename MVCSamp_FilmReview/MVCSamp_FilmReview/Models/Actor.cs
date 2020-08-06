﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class Actor
    {
        [Key]
        public virtual int ActorId { get; set; } //primary key

        [Required]
        public virtual string FirstName { get; set; } //property for first name of actor 

        [Required]
        public virtual string Surname { get; set; } //property for surname of actor

        [Required]
        public virtual DateTime DateofBirth { get; set; } // property for date of birth

        public virtual List<ClsFilm> FilmCastOn { get; set; } //List of films actor has acted
        public virtual List<Comment> Comment { get; set; } // List of comments on the actor

        
    }
}