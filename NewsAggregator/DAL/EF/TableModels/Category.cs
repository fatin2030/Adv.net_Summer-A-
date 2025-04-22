using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
