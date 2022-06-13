using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class ResultContext : DbContext
    {
        public ResultContext (DbContextOptions<ResultContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.Result>? Result { get; set; }
    }
}
