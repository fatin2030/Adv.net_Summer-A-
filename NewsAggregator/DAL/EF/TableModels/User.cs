using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]

        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]

        public string Role { get; set; }
        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<BookMark> BookMarks { get; set; }

    }
}
