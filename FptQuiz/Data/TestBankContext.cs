using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;


namespace FptQuiz.Data
{
    public class TestBankContext : DbContext
    {
        public TestBankContext (DbContextOptions<TestBankContext> options)
            : base(options)
        {
        }
       

        public DbSet<FptQuiz.Model.TestBank>? TestBank { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
      
        }
    }
}
