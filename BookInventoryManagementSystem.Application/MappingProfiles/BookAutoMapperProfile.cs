using AutoMapper;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class BookAutoMapperProfile : Profile
{
    public BookAutoMapperProfile()
    {
        CreateMap<Book, BookViewModelWithId>().ReverseMap();
        CreateMap<Book, BookViewModelWithIdAndReviews>();
        CreateMap<BookViewModelWithoutId, Book>();
    }
}
