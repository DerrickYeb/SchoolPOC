﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Course Code")]
        [Column("CourseId")]
        public int Id { get; set; }
        [StringLength(50,MinimumLength = 5)]
        public string Title { get; set; }
        
    }
}
