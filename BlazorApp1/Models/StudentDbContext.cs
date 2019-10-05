using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasData(
                new
                {
                    StudentId = Guid.NewGuid().ToString(),
                    FirstName = "Sayed",
                    LastName = "Hossain",
                    School = "Hazi Mohosin college"
                },
                new
                {
                    StudentId = Guid.NewGuid().ToString(),
                    FirstName = "Mizanur",
                    LastName = "Rahman",
                    School = "Muslim High School"
                },

                new
                {
                    StudentId = Guid.NewGuid().ToString(),
                    FirstName = "Hasanur",
                    LastName = "Rasid",
                    School = "Nasirabad Boys School"
                }


                );
        }
    }
}
