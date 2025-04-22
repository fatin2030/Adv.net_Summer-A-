using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class ArticleTag
    {
        public int Id { get; set; }

        public virtual Article Article { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }



        public virtual ICollection<Tag> Tags { get; set; }
        [ForeignKey("Tags")]
        public int TagId { get; set; }

     

    }
}
