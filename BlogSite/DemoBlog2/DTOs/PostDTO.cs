using DemoBlog2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBlog2.DTOs
{
    public class PostDTO
    {
        public int id { get; set; }
        public int UId { get; set; }

        public string Title { get; set; }
        public string PostContent { get; set; }


        public System.DateTime PostTime { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

        public PostDTO() { 
            Comments = new List<CommentDTO>();
        }
    }
}