using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

     
        public string Name { get; set; }

        public string UserName { get; set; }
  

        public string Email { get; set; }
       
        public string Password { get; set; }

        
        public string Role { get; set; }
        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<BookMark> BookMarks { get; set; }
    }
}
