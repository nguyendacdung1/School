using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_application.Models;

namespace web_application.Data
{
    public class web_applicationContext : DbContext
    {
        public web_applicationContext (DbContextOptions<web_applicationContext> options)
            : base(options)
        {
        }

        public DbSet<web_application.Models.Employee> Employee { get; set; } = default!;
    }
}
