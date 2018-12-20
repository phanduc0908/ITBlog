using ITBLOG.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITBLOG.WEBUI.Models
{
    public class LastestBlogModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
