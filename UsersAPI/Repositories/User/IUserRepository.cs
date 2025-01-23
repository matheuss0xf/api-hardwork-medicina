using UsersAPI.Dto.User;
using UsersAPI.Models;

namespace UsersAPI.Repositories.User;

public interface IUserRepository
{
    Task<UserModel> GetUserByIdAsync(int userId);
    Task<List<UserModel>> GetAllUsersAsync();
    Task<UserModel> AddUserAsync(UserModel user);
    Task<UserModel> UpdateUserAsync(int userId, UserDtos.UserUpdateDto userUpdateDto);
    Task<UserModel> PatchUserAsync(int userId, UserDtos.UserPatchDto userPatchDto);
    Task DeleteUserAsync(int userId);
}