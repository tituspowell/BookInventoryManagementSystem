using AutoMapper;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class ReviewAutoMapperProfile : Profile
{
    public ReviewAutoMapperProfile()
    {
        CreateMap<ReviewViewModel, Review>()
        .ForMember(dest => dest.Book, opt => opt.Ignore())
        .ForMember(dest => dest.Reviewer, opt => opt.Ignore());

        CreateMap<Review, ReviewViewModelWithBookInfoAndId>();
    }
}
