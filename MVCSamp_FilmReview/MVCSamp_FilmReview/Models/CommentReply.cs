using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class CommentReply
    {
        [Key]
        public virtual int CommentReplyId { get; set; } //Primary key for response to comment

        public virtual int CommentId { get; set; } //Foreign key for responded comment

        public virtual string AuthorId { get; set; } // property for id of owner to response
        
        public virtual string Content { get; set; } //property for response's content

        public virtual int ReviewId { get; set; } //Property for id to the posted response
        public virtual int FilmId { get; set; } //property for film's id
        public virtual int DirectorId { get; set; }//property for film director's id 
        public virtual int ActorId { get; set; } //property for actor's id

    }
}