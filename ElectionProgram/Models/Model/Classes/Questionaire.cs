using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Questionaire
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Question>  Questions { get; set; }
       // public virtual ICollection<Candidate> Candidates { get; set; }
    }
}