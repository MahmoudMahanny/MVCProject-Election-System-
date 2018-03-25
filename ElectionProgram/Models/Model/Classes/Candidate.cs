using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Candidate:Employee
    {
        //public int ID { get; set; }
        [DefaultValue("0")]
        public int NoOfVotes { get; set; }
      
        public virtual Account Account { get; set; }
        public virtual ElectionPrograms ElectionProgram { get; set; }
        public virtual Election Election { get; set; }
    }
}