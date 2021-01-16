using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("SchoolConnection")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
