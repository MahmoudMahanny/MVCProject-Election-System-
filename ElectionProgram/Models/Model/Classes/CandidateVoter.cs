using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class CandidateVoter
    {
        
        public int ID { get; set; }
        [Required]
        [ForeignKey("Candidate")]
        public int candidate_id { get; set; }
        public virtual Candidate Candidate { get; set; }

        [ForeignKey("ApplicationUser")]
        [Required]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}