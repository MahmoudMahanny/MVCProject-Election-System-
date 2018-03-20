using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Candidate:Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DefaultValue("0")]
        public int NoOfVotes { get; set; }
        [DefaultValue("false")]
        public bool IsApplay { get; set; }


        public virtual Account Account { get; set; }
       
        public virtual Election Election { get; set; }
    }
}