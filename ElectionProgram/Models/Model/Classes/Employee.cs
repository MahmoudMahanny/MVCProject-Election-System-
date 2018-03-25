using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Employee
    {

        
        public string  Name{ get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate  { get; set; }
        public string  Gender { get; set; }
       
        public long  NID { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string CareerPosition { get; set; }
        public byte[] PIC { get; set; }



    }
}