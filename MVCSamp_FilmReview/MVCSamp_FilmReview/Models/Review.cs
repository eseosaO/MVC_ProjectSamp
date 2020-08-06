using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class Review
    {
        [Key]
        public virtual int ReviewId { get; set; } //Primary key 
        //[ForeignKey("UserId")]
        public virtual string UserId { get; set; } //Foreign key as a user post a review

        //public virtual User User { get; set; }
        [Required]
        public virtual string ReviewTitle { get; set; } //property for Title of the review on a film
        [Required]
        public virtual DateTime PostDate { get; set; } //property for post date of the review

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; } //property for the review criticing or praising the film

        [Range(1,10)]
        [Required]
        public virtual int ReviewScore { get; set; }

        public virtual List<Comment> Comment { get; set; } //property for list of comments by others on a review
    }
}