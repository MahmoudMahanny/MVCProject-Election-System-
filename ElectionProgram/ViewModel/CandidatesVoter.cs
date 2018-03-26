using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionProgram.Models;

namespace ElectionProgram.ViewModel
{
    public class CandidatesVoter
    {
        public string VoterID { get; set; }
        public int ElectionId { get; set; }

        public List<Candidate> canList{ get; set; }
    }
}