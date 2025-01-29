using AutoMapper;
using BookInventoryManagementSystem.Data.Entities;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class BookAutoMapperProfile : Profile
{
    public BookAutoMapperProfile()
    {
        CreateMap<Book, BookIndexViewModel>();
        CreateMap<BookCreateViewModel, Book>();
        CreateMap<BookEditViewModel, Book>().ReverseMap();
    }
}
