using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Voter:Employee
    {
        public int ID { get; set; }

        public Account Account { get; set;}
        public ICollection<Answer> Answers { get; set; }
    }
}