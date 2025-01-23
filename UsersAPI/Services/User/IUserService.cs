using UsersAPI.Dto.User;
using UsersAPI.Models;

namespace UsersAPI.Services.User;

public interface IUserService
{
    Task<List<UserDtos.UserResponseDto>> GetUsersAsync();
    Task<UserDtos.UserResponseDto> GetUserByIdAsync(int userId);
    Task<UserDtos.UserResponseDto> AddUserAsync(UserDtos.UserAddDto userAddDto);
    Task<UserDtos.UserResponseDto> UpdateUserAsync(int userId, UserDtos.UserUpdateDto userUpdateDto);
    Task<UserDtos.UserResponseDto> PatchUserAsync(int userId, UserDtos.UserPatchDto userPatchDto);
    Task<bool> DeleteUserAsync(int userId);
}