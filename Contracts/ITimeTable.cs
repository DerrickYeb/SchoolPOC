using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITimeTable
    {
        Task<IEnumerable<TimeTable>> GetAllTimeTableAsync(bool trackChanges);
        Task<TimeTable> GetTimeTableAsync(Guid companyId, bool trackChanges);
        void CreateTimeTable(TimeTable timeTable);
        Task<IEnumerable<TimeTable>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCompany(TimeTable timeTable);
    }
}
