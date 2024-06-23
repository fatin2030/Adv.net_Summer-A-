using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask2.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int CreditHour { get; set; }
        [Required(ErrorMessage ="Please enter Course type")]

        public string Type { get; set; }

    }
}