﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
        Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);
        void CreateStudent(Student student);
        Task<IEnumerable<Student>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteStudent(Student student);
    }
}
