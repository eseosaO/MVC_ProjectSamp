using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class Comment
    {
        [Key]
        public virtual int CommentId { get; set; } //Primary key

        public virtual string AuthorId { get; set; } //property for owner of the comment
        public virtual int ReviewId { get; set; } //property for post id of the review to receive comment
        public virtual int FilmId { get; set; } //Foreign key from Film table
        public virtual int ActorId { get; set; } //Foreign key from actor table
        public virtual int DirectorId { get; set; } //Foreign key from director table
                                                    //public virtual User User { get; set; }//Navigational property for user who post a comment
        public virtual string Content { get; set; } //property for holding the content of comment

        //[Range(1, 10)]
        [Required]
        public virtual float UserScore { get; set; } //property for user's score on comment
        //public virtual string Email { get; set; }

        public virtual List<CommentReply> CommentResponse { get; set; } //property for list of reply to comments
        public virtual bool IsBlocked { get; set; } //property to indicate whether a comment is blocked or not.
    }
}