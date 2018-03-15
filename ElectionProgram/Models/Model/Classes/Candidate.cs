using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Candidate:Employee
    {
<<<<<<< HEAD:ElectionProgram/Models/Model/Candidate.cs
        //change
        public int NoOfVotes { get; set; }
=======
        //public int ID { get; set; }
        public int? NoOfVotes { get; set; }
>>>>>>> 30c6e408bb89d6d87169c2b3e6b6ac2c6b5e1a0c:ElectionProgram/Models/Model/Classes/Candidate.cs
       

        public virtual Account Account { get; set; }
        public virtual ElectionPrograms ElectionProgram { get; set; }
        public virtual Election Election { get; set; }
    }
}