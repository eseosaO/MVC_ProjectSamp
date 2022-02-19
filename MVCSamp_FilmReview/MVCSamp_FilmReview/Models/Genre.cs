using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSamp_FilmReview.Models
{
    public class Genre
    {
        public List<string> GenreList
        {
            get
            {
                List<string> GenList = new List<string>();
                GenList.Add("Other");
                GenList.Add("Action");
                GenList.Add("Adventure");
                GenList.Add("Science Fiction");
                GenList.Add("Horror");
                GenList.Add("Thriller");
                GenList.Add("Comedy");
                GenList.Add("Romance");
                GenList.Add("Drama");
                return GenList;
            }
        }
    }
}