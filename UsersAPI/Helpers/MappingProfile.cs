using AutoMapper;
using UsersAPI.Dto.User;
using UsersAPI.Models;

namespace UsersAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDtos.UserResponseDto>();
            CreateMap<UserDtos.UserAddDto, UserModel>();
            CreateMap<UserDtos.UserUpdateDto, UserModel>();
            CreateMap<UserDtos.UserPatchDto, UserModel>();
        }
    }
}