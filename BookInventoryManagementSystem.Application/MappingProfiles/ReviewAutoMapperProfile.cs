using AutoMapper;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class ReviewAutoMapperProfile : Profile
{
    public ReviewAutoMapperProfile()
    {
        // For read only view in the Book Details view
        CreateMap<ReviewViewModel, Review>()
        .ForMember(dest => dest.Book, opt => opt.Ignore())
        .ForMember(dest => dest.Reviewer, opt => opt.Ignore());

        // For Edit and viewing all reviews
        CreateMap<Review, ReviewViewModelWithBookInfoAndId>().ReverseMap();
    }
}
