using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Author;
using LibraryManagementSystem.Domain.ViewModels.Book;
using LibraryManagementSystem.Domain.ViewModels.Member;

namespace LibraryManagementSystem.Api.AutoMapper
{
    public class AutoMapperSetting : Profile
    {
        public AutoMapperSetting()
        {
            // Author
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<Author, AuthorCreateModel>();
            CreateMap<AuthorCreateModel, Author>();
            CreateMap<Author, AuthorEditModel>();
            CreateMap<AuthorEditModel, Author>();

            // Book
            CreateMap<Book, BookViewModel>()
                .ForMember(d => d.AuthorName, s => s.MapFrom(m => m.Author.Name));
            CreateMap<BookViewModel, Book>();

            CreateMap<Book, BookCreateModel>();
            CreateMap<BookCreateModel, Book>();
            CreateMap<Book, BookEditModel>();
            CreateMap<BookEditModel, Book>();

            // Member
            CreateMap<Member, MemberViewModel>()
                .ForMember(d => d.MemberTypeName, s => s.MapFrom(m => m.MemberType.Name));
            CreateMap<MemberViewModel, Member>();

            CreateMap<Member, MemberCreateModel>();
            CreateMap<MemberCreateModel, Member>();
            CreateMap<Member, MemberEditModel>();
            CreateMap<MemberEditModel, Member>();
        }
    }
}