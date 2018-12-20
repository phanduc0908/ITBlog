using AutoMapper;
using ITBLOG.CORE.AdminView;
using ITBLOG.CORE.Models;
using ITBLOG.CORE.ViewModels;
using System;
using System.Linq;

namespace ITBLOG.INFRA.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogViewItem, Blog>();
            CreateMap<Blog, BlogViewItem>()
                .ForMember(dst => dst.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dst => dst.ReleaseDay, opt => opt.MapFrom(src => src.ReleaseDay))
                .ForMember(dst => dst.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<Blog, ChangeBlog>()
                .ForMember(dst => dst.BlogId, opt => opt.MapFrom(src => src.BlogId)) // Destination(dst) được map từ Resource(src)
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Blog, BlogIndex>()
                .ForMember(dst => dst.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dst => dst.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<Blog, LastestBlog>()
                .ForMember(dst => dst.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dst => dst.ReleaseDay, opt => opt.MapFrom(src => src.ReleaseDay));

            CreateMap<Tag, TagViewItem>()
                .ForMember(dst => dst.TagId, opt => opt.MapFrom(src => src.TagId))
                .ForMember(dst => dst.TagName, opt => opt.MapFrom(src => src.TagName));

            CreateMap<Admin, UserView>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<Comment, CommentView>()
                .ForMember(dst => dst.CommnentId, opt => opt.MapFrom(src => src.CommnentId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content));
        }
    }
}
