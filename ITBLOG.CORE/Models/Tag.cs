using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.CORE.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public int BlogId { get; set; }
        public Blog blog { get; set; }
    }
}
