using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Question
    {
        public int ID{ get; set; }
        public string question { get; set; }

        [ForeignKey("Questionaire")]
        public int QuestionaireID { get; set; }
        public virtual Questionaire  Questionaire { get; set; }


    }
}