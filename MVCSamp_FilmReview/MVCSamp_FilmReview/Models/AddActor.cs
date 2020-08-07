using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class AddActor
    {
        [Key]
        public virtual int AddActorId { get; set; }
        
        public virtual int FilmId { get; set; }
        
        public virtual int ActorId { get; set; }

        public virtual ClsFilm Film { get; set; }
        public virtual Actor Actor { get; set; }

    }
}