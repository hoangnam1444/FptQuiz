using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class UniContext : DbContext
    {
        public UniContext (DbContextOptions<UniContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.Uni>? Uni { get; set; }
    }
}
