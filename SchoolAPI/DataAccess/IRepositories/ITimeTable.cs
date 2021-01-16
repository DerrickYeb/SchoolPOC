using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.DataAccess
{
    public interface ITimeTable
    {
        Task<IEnumerable<TimeTable>> GetAllTimeTableAsync(bool trackChanges);
        Task<TimeTable> GetTimeTableAsync(Guid companyId, bool trackChanges);
        void CreateTimeTable(TimeTable timeTable);
        Task<IEnumerable<TimeTable>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteTimeTable(TimeTable timeTable);
    }
}
