using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using School.Models;
using School.Data;

namespace School.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                // Look for any students.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }
                var students = new Student[]
                {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
                };
                foreach (Student s in students)
                {
                    context.Student.Add(s);
                }
                context.SaveChanges();
                var courses = new Course[]
                {
                    new Course{Title="Chemistry",Credits=3},
                    new Course{Title="Microeconomics",Credits=3},
                    new Course{Title="Macroeconomics",Credits=3},
                    new Course{Title="Calculus",Credits=4},
                    new Course{Title="Trigonometry",Credits=4},
                    new Course{Title="Composition",Credits=3},
                    new Course{Title="Literature",Credits=4}
                };
                foreach (Course c in courses)
                {
                    context.Course.Add(c);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentID=1,Grade=Grade.A},
                    new Enrollment{StudentID=1,Grade=Grade.C},
                    new Enrollment{StudentID=1,Grade=Grade.B},
                    new Enrollment{StudentID=2,Grade=Grade.B},
                    new Enrollment{StudentID=2,Grade=Grade.F},
                    new Enrollment{StudentID=2,Grade=Grade.F},
                    new Enrollment{StudentID=3},
                    new Enrollment{StudentID=4},
                    new Enrollment{StudentID=4,Grade=Grade.F},
                    new Enrollment{StudentID=5,Grade=Grade.C},
                    new Enrollment{StudentID=6},
                    new Enrollment{StudentID=7,Grade=Grade.A},
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollment.Add(e);
                }
                context.SaveChanges();




            }


            

            
        }
    }
}
