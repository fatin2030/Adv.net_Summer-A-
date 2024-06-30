using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProject.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public string Uname { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
    }
}