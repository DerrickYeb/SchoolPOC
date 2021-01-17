using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Guidian { get; set; }
        [DisplayName("Guidian Contact")]
        public string GuideanContact { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        [DisplayName("Academic Year")]
        public string AcademicYear { get; set; }
        public string Address { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
