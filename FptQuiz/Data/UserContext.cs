using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Model;
using Microsoft.AspNetCore.Mvc;

namespace FptQuiz.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<FptQuiz.Model.User>? User { get; set; }

        public static implicit operator ControllerContext(UserContext v)
        {
            throw new NotImplementedException();
        }
    }
}
