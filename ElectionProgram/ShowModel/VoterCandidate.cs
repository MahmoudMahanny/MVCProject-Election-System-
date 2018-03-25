using ElectionProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.ShowModel
{
    public class VoterCandidate
    {
        public int  voterID { get; set; }
        public string votername{ get; set; }
        public string voterimagPath { get; set; }
        public string candidatename { get; set; }
        public string candidateimagepath { get; set; }
       
    }
}