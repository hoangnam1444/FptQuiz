using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class MajorContext : DbContext
    {
        public MajorContext (DbContextOptions<MajorContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.Major>? Major { get; set; }
    }
}
