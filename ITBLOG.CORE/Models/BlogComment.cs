using ITBLOG.CORE.ViewModels;
using System.Collections.Generic;

namespace ITBLOG.CORE.Models
{
    public class BlogComment
    {
        public Blog BlogDetail { get; set; }
        public ChangeBlog NextBlog { get; set; }
        public ChangeBlog PreviousBlog { get; set; }
        public int LastBlogId { get; set; }
        public int FirstBlogId { get; set; }

        public int NumberComments { get; set; }
        public IEnumerable<CommentView> Comments { get; set; }
        public IEnumerable<BlogViewItem> Blogs { get; set; }
        public IEnumerable<LastestBlog> LastBlogs { get; set; }
        public IEnumerable<TagViewItem> ListTagNames { get; set; }

    }
}
