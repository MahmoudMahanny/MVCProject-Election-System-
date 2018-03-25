using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
         public string Symbol  { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime ProgramEndDate { get; set; }

        [ForeignKey("Can")]
        public int CID { get; set; }
        public virtual Candidate Can { get; set; }

    }
}