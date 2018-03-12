using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Winner
    {
        public int ID { get; set; }

        public virtual Questionaire Questionaire { get; set; }
        public virtual  Candidate Candidate { get; set; }

    }
}