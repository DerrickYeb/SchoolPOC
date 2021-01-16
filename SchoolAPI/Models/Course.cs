using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Course
    {
        [Column("CourseId")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
    }
}
