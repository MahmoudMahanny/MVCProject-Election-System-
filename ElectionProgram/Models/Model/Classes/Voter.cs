using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Voter:Employee
    {
<<<<<<< HEAD:ElectionProgram/Models/Model/Voter.cs
        public bool IsVote { get; set; }
=======
        //public int ID { get; set; }

>>>>>>> 30c6e408bb89d6d87169c2b3e6b6ac2c6b5e1a0c:ElectionProgram/Models/Model/Classes/Voter.cs
        public Account Account { get; set;}
        public ICollection<Answer> Answers { get; set; }
    }
}