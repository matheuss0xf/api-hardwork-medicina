using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Dto.User;
using UsersAPI.Models;
using System;

namespace UsersAPI.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to add user. The email may already be in use.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<UserModel> UpdateUserAsync(int userId, UserDtos.UserUpdateDto userUpdateDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            existingUser.Name = userUpdateDto.Name;
            existingUser.Email = userUpdateDto.Email;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<UserModel> PatchUserAsync(int userId, UserDtos.UserPatchDto userPatchDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            if (!string.IsNullOrEmpty(userPatchDto.Name)) existingUser.Name = userPatchDto.Name;
            if (!string.IsNullOrEmpty(userPatchDto.Email)) existingUser.Email = userPatchDto.Email;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
