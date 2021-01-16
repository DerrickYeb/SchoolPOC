using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SchoolAPI.DataAccess.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get;}
        ICourseRepository Course { get; }
        IUserRepository User { get; }
        ITimeTable TimeTable { get; }

        Task Save();
    }
}