using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITBLOG.WEBUI.Models
{
    public class CommentModel
    {
        public int CommnentId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
