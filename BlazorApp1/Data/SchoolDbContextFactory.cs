using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
    public class SchoolDbContextFactory:IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
            var connStr = ConfigurationHelper.GetCurrentSetting("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);
            return new StudentDbContext(optionsBuilder.Options);
        }
    }
}
