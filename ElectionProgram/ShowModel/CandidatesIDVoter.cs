using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionProgram.Models;

namespace ElectionProgram.ShowModel
{
    public class CandidatesIDVoter
    {
        public int VoterID { get; set; }
        public List<Candidate> canList{ get; set; }
    }
}