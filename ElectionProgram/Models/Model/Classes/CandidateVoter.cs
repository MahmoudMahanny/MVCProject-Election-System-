using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class CandidateVoter
    {
        public int ID { get; set; }
        [ForeignKey("Candidate")]
        public int candidate_id { get; set; }
        public virtual Candidate Candidate { get; set; }
        [ForeignKey("Voter")]
        public int Voter_id { get; set; }
        public virtual Voter Voter { get; set; }

    }
}