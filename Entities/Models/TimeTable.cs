using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TimeTable
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string Time { get; set; }
    }
}
