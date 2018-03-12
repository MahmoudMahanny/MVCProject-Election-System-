using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string answer { get; set; }
        public  virtual Question Question { get; set; }
        public virtual Voter voter { get; set; }
    }
}