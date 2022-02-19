using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class Director
    {
        [Key]
        public virtual int DirectorId { get; set; } //Primary key

        [StringLength(50)]
        public virtual string FirstName { get; set; } //Director's first name

        [StringLength(50)]
        public virtual string LastName { get; set; } //Director's last name

        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DateofBirth { get; set; } //Director's date of birth

        public virtual List<ClsFilm> DirectorFilms { get; set; } //List of films done by director
        
        public virtual List<Comment> Comment { get; set; } //List of comments on director

        public virtual string User { get; set; }//Logged-in User to input director 
    }
}