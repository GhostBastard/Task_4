using AuthorBookWebApp.DbData.DbModel;
using AuthorBookWebApp.Models;
using AutoMapper;

namespace AuthorBookWebApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDbModel, AuthorViewModel>().ReverseMap();
            CreateMap<BookDbModel, BookViewModel>().ReverseMap();
        }
    }
}
