using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class TrendingMetric
    {

        public int Id { get; set; } 
        public virtual  Article Article { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
    }
}
