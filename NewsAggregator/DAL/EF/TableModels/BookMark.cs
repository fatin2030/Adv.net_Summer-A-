using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class BookMark
    {
       

        public int Id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
      
        public int UserId { get; set; }

        public virtual ICollection<  Article> Articles { get; set; }
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
