using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;

namespace FptQuiz.Data
{
    public class RolesContext : DbContext
    {
        public RolesContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-I1RR2CD\\SQLEXPRESS;Initial Catalog=FptQuiz;Persist Security Info=True;User ID=sa;Password=123456");
            base.OnConfiguring(builder);
        }
        public RolesContext (DbContextOptions<RolesContext> options)
            : base(options)
        {

        }

        public DbSet<FptQuiz.Model.Role>? Role { get; set; }
    }
}
