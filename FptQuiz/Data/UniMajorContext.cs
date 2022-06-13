using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class UniMajorContext : DbContext
    {
        public UniMajorContext (DbContextOptions<UniMajorContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.UniMajor>? UniMajor { get; set; }
    }
}
