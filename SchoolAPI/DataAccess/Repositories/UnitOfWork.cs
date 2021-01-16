using SchoolAPI.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SchoolAPI.DataAccess.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Student = new StudentRepository(_context);
            
        }

        public IStudentRepository Student { get; private set; }

        public ICourseRepository Course { get; private set; }

        public IUserRepository User { get; private set; }

        public ITimeTable TimeTable { get; private set; }

        public void Dispose() => _context.Dispose();

        public Task Save() => _context.SaveChangesAsync();
    }
}