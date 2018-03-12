using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Admin:Employee
    {
        public int ID{ get; set; }

        public Account Account { get; set; }
        public ICollection<Election> Election { get; set; }
        public ICollection<Questionaire> Questionaire { get; set; }

    }
}