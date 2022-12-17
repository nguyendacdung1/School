using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using web_application.Models;
using web_application.Data;
using System.Diagnostics;

namespace web_application.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new web_applicationContext(serviceProvider
                .GetRequiredService<DbContextOptions<web_applicationContext>>()))
            {
                // Look for any students.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                 new Employee
                 {
                     Id = "EM001",
                     Name = "Jonh Carter",
                     Department = "HR",
                     Salary = 3000,
                 },
                 new Employee
                 {
                     Id = "EM002",
                     Name = "Michael Bean",
                     Department = "SC",
                     Salary = 1300,
                 },
                 new Employee
                 {
                     Id = "EM003",
                     Name = "Jimmy Floy",
                     Department = "MD",
                     Salary = 2000,
                 },
                 new Employee
                 {
                     Id = "EM004",
                     Name = "Mary Brown",
                     Department = "MD",
                     Salary = 2000,
                 }
                );

                context.SaveChanges();
            }
        }
    }
}