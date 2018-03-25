using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ElectionProgram.Models
{
    public class ApplicationUser:IdentityUser
    {
        //[DataType(DataType.Date)]
        //[Required(ErrorMessage = "Kindly , Enter Birthdate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
       
        public string Gender { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[DisplayName("National ID")]

     //   [RegularExpression(@"^(2|3)[0-9][1-9][0-1][1-9][0-3][0-9](01|02|03|04|11|12|13|14|15|16|17|18|19|21|22|23|24|25|26|27|28|29|31|32|33)\d\d\d\d\d$", ErrorMessage = "National ID is not Valid")]
        public long NID { get; set; }

        public string Address { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[DisplayName("Phone Number")]
        ////[RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage ="Phone Number is not Valid")]
        //public int Phone { get; set; }

       // [Required(ErrorMessage = "Kindly , Enter Career Position")]
        //[DisplayName("Career Position")]
        public string CareerPosition { get; set; }

        //[DisplayName("Profile Image")]
        public string ImagePath { get; set; }

    }
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("db")
        {
        }
        internal static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Winner> Winner { get; set; }
        public virtual DbSet<Questionaire> Questionaire { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<CandidateVoter> CandidateVoter { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }
        public virtual DbSet<ElectionPrograms> ElectionProgram { get; set; }
        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<ElectionSymbols> electionSymbols { get; set; }

        public System.Data.Entity.DbSet<ElectionProgram.Models.RegistrationVM> RegistrationVMs { get; set; }

    }

}