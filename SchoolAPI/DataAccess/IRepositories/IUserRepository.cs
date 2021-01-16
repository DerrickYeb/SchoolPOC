using SchoolAPI.DataAccess;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.DataAccess
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(Guid userId, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
    }
}
