using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolAPI.Models
{
    public class Student
    {
        [Column("StudentId")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Guidean { get; set; }
        public string GuideanContact { get; set; }
        public string Class { get; set; }
        public string AcademicYear { get; set; }
        public string Address { get; set; }
        public ICollection<Course> Courses { get; set; }
        public IEnumerable<SelectListItem> SelectedCourses { get; set; }
    }
}
