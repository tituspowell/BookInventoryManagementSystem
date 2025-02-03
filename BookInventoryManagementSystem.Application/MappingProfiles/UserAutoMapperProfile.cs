using AutoMapper;
using BookInventoryManagementSystem.Application.ViewModels.Users;

namespace BookInventoryManagementSystem.Application.MappingProfiles;

internal class UserAutoMapperProfile : Profile
{
    public UserAutoMapperProfile()
    {
        CreateMap<ApplicationUser, UserViewModel>();
    }
}
