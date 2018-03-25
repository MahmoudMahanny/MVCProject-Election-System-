using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Candidate:Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [DefaultValue("0")]
        public int NoOfVotes { get; set; }
<<<<<<< HEAD
        [DefaultValue("false")]
        
        public bool IsApplay { get; set; }


=======
      
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d
        public virtual Account Account { get; set; }
       
        public virtual Election Election { get; set; }
    }
}