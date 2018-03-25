using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class RegistrationVM
    {
        public int ID { get; set; }
        //[Required]
        public string UserName { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        public string   Password { get; set; }
        [DataType(DataType.EmailAddress)]
        //[Required]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Kindly , Enter Birthdate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("National ID")]

        //[RegularExpression(@"^(2|3)[0-9][1-9][0-1][1-9][0-3][0-9](01|02|03|04|11|12|13|14|15|16|17|18|19|21|22|23|24|25|26|27|28|29|31|32|33)\d\d\d\d\d$", ErrorMessage = "National ID is not Valid")]
        public long NID { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        //[RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage ="Phone Number is not Valid")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Kindly , Enter Career Position")]
        [DisplayName("Career Position")]
        public string CareerPosition { get; set; }

        [DisplayName("Profile Image")]
        public string ImagePath { get; set; }
    }
    public class LogInVM
    {
        //[Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}