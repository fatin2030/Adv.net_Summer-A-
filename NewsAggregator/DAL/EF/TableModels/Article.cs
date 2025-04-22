using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]

        public string Title { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]

        public string Content { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int AuthorId { get; set; }
        public Category Category { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<BookMark> BookMarks { get; set; }



    }
}
