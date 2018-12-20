using ITBLOG.CORE.ViewModels;
using System.Collections.Generic;

namespace ITBLOG.CORE.Models
{
    public class BlogComment
    {
        public Blog blog { get; set; }
        public ChangeBlog nextBlog { get; set; }
        public ChangeBlog previousBlog { get; set; }
        public int lastBlogId { get; set; }
        public int firstBlogId { get; set; }

        public int NumberComments { get; set; }
        public IEnumerable<CommentView> Comments { get; set; }
        public IEnumerable<BlogViewItem> Blogs { get; set; }
        public IEnumerable<LastestBlog> LastBlogs { get; set; }
        public IEnumerable<TagViewItem> ListTagNames { get; set; }

    }
}
