using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.CORE.AdminView
{
    public class BlogAdmin
    {
        public int NumberBlog { get; set; } 
    }
    public class BlogIndex
    {
        public int BlogId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
