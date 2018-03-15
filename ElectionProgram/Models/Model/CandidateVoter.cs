using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class CandidateVoter
    {
        public int ID { get; set; }


        public virtual Candidate Candidate { get; set; }
        public virtual ICollection<Voter> Voters { get; set; }
    }
}