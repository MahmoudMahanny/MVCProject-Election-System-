using ElectionProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.ViewModel
{
    public class ElectionCadidates
    {
        public string AppUserID { get; set; }
        public int ElectionId { get; set; }
        public List<Candidate> candidateList { get; set; }
    }
}