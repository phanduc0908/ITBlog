using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITBLOG.CORE.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDay { get; set; }
        public string Genre { get; set; }
        public string ContentHeader { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
