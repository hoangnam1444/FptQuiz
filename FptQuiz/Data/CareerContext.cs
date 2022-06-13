using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class CareerContext : DbContext
    {
        public CareerContext (DbContextOptions<CareerContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.Career>? Career { get; set; }
    }
}
