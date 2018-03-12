using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Candidate:Employee
    {
        //public int ID { get; set; }
        public int? NoOfVotes { get; set; }
       

        public virtual Account Account { get; set; }
        public virtual ElectionPrograms ElectionProgram { get; set; }
        public virtual Election Election { get; set; }
    }
}