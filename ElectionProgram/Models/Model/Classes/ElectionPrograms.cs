using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class ElectionPrograms
    {
        public int ID{ get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string Program { get; set; }
        public byte[] Symbol  { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime ProgramEndDate { get; set; }

       // public virtual Candidate Candidate { get; set; }


    }
}