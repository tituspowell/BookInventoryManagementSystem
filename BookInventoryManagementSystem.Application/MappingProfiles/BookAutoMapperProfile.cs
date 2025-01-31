using AutoMapper;
using BookInventoryManagementSystem.Data.Entities;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class BookAutoMapperProfile : Profile
{
    public BookAutoMapperProfile()
    {
        CreateMap<Book, BookViewModelWithId>().ReverseMap();
        CreateMap<BookViewModelWithoutId, Book>();
    }
}
