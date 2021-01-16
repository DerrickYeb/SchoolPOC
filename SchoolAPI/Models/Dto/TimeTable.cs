
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Dto
{
    public class TimeTable
    {
        public Course Course { get; set; }
        public string Time { get; set; }
    }
}
