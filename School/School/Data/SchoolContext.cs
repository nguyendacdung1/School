using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<School.Models.Student> Student { get; set; } = default!;
        public DbSet<School.Models.Course> Course { get; set; } = default!;
        public DbSet<School.Models.Enrollment> Enrollment { get; set; } = default!;

    }
}
