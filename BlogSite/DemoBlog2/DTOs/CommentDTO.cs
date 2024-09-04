using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBlog2.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User ID is required.")]
        public int UId { get; set; }

        [Required(ErrorMessage = "Post ID is required.")]
        public int PId { get; set; }

        [Required(ErrorMessage = "Comment body is required.")]
        [StringLength(500, ErrorMessage = "Comment body cannot exceed 500 characters.")]
        public string CommentBody { get; set; }

        [Required(ErrorMessage = "Comment time is required.")]
        public System.DateTime CommentTime { get; set; }
    }
}