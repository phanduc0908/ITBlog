using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITBLOG.CORE.ViewModels
{
    public class BlogViewItem
    {
        public int BlogId { get; set; }
        [Required(ErrorMessage ="Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Release day is required")]
        [DataType(DataType.Currency)]
        public DateTime ReleaseDay { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Content header is required")]
        [MinLength(10, ErrorMessage ="Min length is 10 character")]
        public string ContentHeader { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public int NumberComments { get; set; }
    }
}
