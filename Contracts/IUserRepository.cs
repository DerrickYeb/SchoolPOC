using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<TimeTable>> GetAllTimeTableAsync(bool trackChanges);
        Task<TimeTable> GetTimeTableAsync(Guid timeTableId, bool trackChanges);
        void CreateTimeTable(TimeTable timeTable);
        void DeleteTimeTable(TimeTable timeTable);
    }
}
