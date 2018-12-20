using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.CORE.Models
{
    public class Comment
    {
        public int CommnentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog blog { get; set; }
    }

}
