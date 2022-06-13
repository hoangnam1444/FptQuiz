using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class TestTypeContext : DbContext
    {
        public TestTypeContext (DbContextOptions<TestTypeContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.TestType>? TestType { get; set; }
    }
}
