using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAPI.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }
    }
}