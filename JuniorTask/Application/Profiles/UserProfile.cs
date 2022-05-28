using AutoMapper;
using JuniorTask.Application.User_Service.DTO;
using JuniorTask.Infrastructure.Entities;

namespace JuniorTask.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequestDto, User>();

            CreateMap<User, AddUserResponseDto>();

            CreateMap<User, FilteredUserResponseDto>().ForMember(dest => dest.Gender,
                opt => opt.MapFrom(x =>
                    x.Gender.Name.ToString()));
        }
    }
}
