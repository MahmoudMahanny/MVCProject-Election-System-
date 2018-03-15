using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Question
    {
        public int ID{ get; set; }
        public string question { get; set; }

        public virtual Questionaire  Questionaire { get; set; }


    }
}