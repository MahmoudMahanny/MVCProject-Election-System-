using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Question
    {
        public int ID{ get; set; }
        [Required(ErrorMessage = "Kindly, Enter the Question")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length 3:50 char")]
        public string question { get; set; }

        [ForeignKey("Questionaire")]
        public int QuestionaireID { get; set; }
        public virtual Questionaire  Questionaire { get; set; }


    }
}