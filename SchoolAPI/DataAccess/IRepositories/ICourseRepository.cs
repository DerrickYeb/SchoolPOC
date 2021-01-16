using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.DataAccess
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges);
        Task<Course> GetCourseAsync(Guid courseId, bool trackChanges);
        void CreateCourse(Course course);
        Task<IEnumerable<Course>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCourse(Course course);
    }
}
