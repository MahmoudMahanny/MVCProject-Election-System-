using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Voter:Employee
    {
<<<<<<< HEAD
        public int ID { get; set; }
=======
        //public int ID { get; set; }
        [DefaultValue(false)]
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d
        public bool IsVote { get; set; }
        public Account Account { get; set;}
        public ICollection<Answer> Answers { get; set; }
        public int CandidateID { get; set; }
    }
}