using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBlog2.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Uname { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

      
        public DateTime LogTime { get; set; }
    }
}