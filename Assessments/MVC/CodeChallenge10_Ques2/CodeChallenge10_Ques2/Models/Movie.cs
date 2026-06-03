using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge10_Ques2.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}