using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class Election
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Kindly, Enter the Name")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length 3:50 char")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Kindly, Enter the Description")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length 3:50 char")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime  StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }

        public virtual Admin Admin { get; set; }
        public ICollection<Candidate> candidate { get; set; }
        public ICollection<ElectionSymbols> symbols { get; set; }





    }
}