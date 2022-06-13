using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class MajorResultContext : DbContext
    {
        public MajorResultContext (DbContextOptions<MajorResultContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.MajorResult>? MajorResult { get; set; }
    }
}
