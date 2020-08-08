using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCSamp_FilmReview.Models
{
    public class ClsFilm
    {      
        [Required]
        [Key]
        public virtual int FilmId { get; set; } //Primary key of Film Model

        [Required]
        public virtual string FilmName { get; set; } //Declared property for name of Film 

        
        [StringLength(800)]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; } // Declared property to describe the film

        [Required]
        public virtual int DirectorId { get; set; } //Foreign key for director of film
        public virtual Director Director { get; set; } //Navigational property for Director

        public virtual string GenreName { get; set; } //Declared property of Genre name (selected from Genre list) for the Game


        public virtual List<Actor> Cast { get; set; } //Declared cast for the Film
        public virtual List<Review> Reviews { get; set; } //Declared list of reviews for film

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual string ReleaseDate { get; set; } //Declared property for the release date of film

        
        
        //public virtual float Score { get; set; }  //Declared score for the film

        public virtual float AverageScore { get; set; } //Declared property to hold the average of scores for film 
        public virtual string User { get; set; } //Logged-in User to input film 

    }
}