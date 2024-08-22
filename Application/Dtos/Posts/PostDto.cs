using Application.Common.Mappings;
using AutoMapper;
using Domain.Enums;
using Domain.Models;

namespace Application.Dtos.Posts
{
    public class PostDto : IMapFrom<Post>
    {
        //public Guid Id { get; set; }
        //public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = string.Empty;
        //public string ShortDescription { get; set; } = string.Empty;
        //public string FullPost { get; set; } = string.Empty;
        //public Category Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                ;

            //profile.CreateMap<Post, PostDto>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            //    .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
            //    .ForMember(p => p.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            //    ;
        }
    }
}