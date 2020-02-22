using AutoMapper;
using Ccsrb.Dtos;
using Ccsrb.Entities;

namespace Ccsrb.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();
            
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();
            
            CreateMap<ArticleImage, ArticleImageDto>();
            CreateMap<ArticleImageDto, ArticleImage>();
            
            CreateMap<ArticleTag, ArticleTagDto>();
            CreateMap<ArticleTagDto, ArticleTag>();
            
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
            
            CreateMap<PollAnswer, PollAnswerDto>();
            CreateMap<PollAnswerDto, PollAnswer>();
            
            CreateMap<Poll, PollDto>();
            CreateMap<PollDto, Poll>();
            
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
            
            CreateMap<UserPollAnswer, UserPollAnswerDto>();
            CreateMap<UserPollAnswerDto, UserPollAnswer>();
            
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
