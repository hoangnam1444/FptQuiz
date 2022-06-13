using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class LearningPartContext : DbContext
    {
        public LearningPartContext (DbContextOptions<LearningPartContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.LearningPart>? LearningPart { get; set; }
    }
}
