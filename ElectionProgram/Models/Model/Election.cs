using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Election
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Admin Admin { get; set; }
        public ICollection<Candidate> candidate { get; set; }
        public ICollection<ElectionSymbols> symbols { get; set; }





    }
}