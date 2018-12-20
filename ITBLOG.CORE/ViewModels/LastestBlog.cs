using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.CORE.ViewModels
{
    public class LastestBlog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDay { get; set; }
    }
}
