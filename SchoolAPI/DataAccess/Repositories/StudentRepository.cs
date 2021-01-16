using DataAccess.Repositories;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SchoolAPI.DataAccess.Repositories
{
    public class StudentRepository:Repository<Student>,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context) { }


        public void CreateStudent(Student student) => Create(student);

        public void DeleteStudent(Student student) => Delete(student);

        public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges)
        =>
            await FindAll(trackChanges)
            .OrderBy(c => c.FirstName)
            .ToListAsync();

        public async Task<IEnumerable<Student>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        =>
           await FindByCondition(c => ids.Contains(c.Id), trackChanges)
            .ToListAsync();

        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges)
       =>
            await FindByCondition(c => c.Id.Equals(studentId), trackChanges)
            .SingleOrDefaultAsync();
    }
}