using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class ElectionSymbols
    {
        public int ID { get; set; }
        public byte[] symbol { get; set; }

        public virtual Election election { get; set; }

    }
}