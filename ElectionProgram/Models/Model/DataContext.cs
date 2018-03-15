using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectionProgram.Models
{
    public class DataContext:DbContext
    {
        //Alaa
        //public DataContext():base("Data Source=.;Initial Catalog=Election;Integrated Security=True")
        //mahmoud
        //public DataContext():base(@"Data Source=DESKTOP-C3NTTGB\M_MAHANNY;Initial Catalog=ElectionSystem;Integrated Security=True")
            //Mohamed
        public DataContext() : base("Data Source=MOHAMEDSAYED-PC;Initial Catalog=ElectionSystem;Integrated Security=True")

        { }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Winner> Winners { get; set; }
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


    }
}