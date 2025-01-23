using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Dto.User;
using UsersAPI.Models;
using UsersAPI.Repositories.User;
using System;

namespace UsersAPI.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDtos.UserResponseDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDtos.UserResponseDto>>(users); // Retorna lista de usuários
        }

        public async Task<UserDtos.UserResponseDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                return _mapper.Map<UserDtos.UserResponseDto>(user); // Retorna o usuário encontrado
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("User not found"); // Lança exceção se não encontrar
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}"); // Lança exceção em caso de erro inesperado
            }
        }

        public async Task<UserDtos.UserResponseDto> AddUserAsync(UserDtos.UserAddDto userAddDto)
        {
            try
            {
                var userModel = _mapper.Map<UserModel>(userAddDto);
                var createdUser = await _userRepository.AddUserAsync(userModel);
                return _mapper.Map<UserDtos.UserResponseDto>(createdUser); // Retorna o usuário criado
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key"))
                {
                    throw new InvalidOperationException("Email already in use"); // Lança exceção de conflito de chave
                }
                throw new Exception("An error occurred while creating the user"); // Lança exceção genérica
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}"); // Lança exceção em caso de erro inesperado
            }
        }

        public async Task<UserDtos.UserResponseDto> UpdateUserAsync(int userId, UserDtos.UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = _mapper.Map<UserDtos.UserUpdateDto>(userUpdateDto);
                var updatedUser = await _userRepository.UpdateUserAsync(userId, user);
                return _mapper.Map<UserDtos.UserResponseDto>(updatedUser); // Retorna o usuário atualizado
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("User not found"); // Lança exceção se não encontrar
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}"); // Lança exceção em caso de erro inesperado
            }
        }

        public async Task<UserDtos.UserResponseDto> PatchUserAsync(int userId, UserDtos.UserPatchDto userPatchDto)
        {
            try
            {
                var user = _mapper.Map<UserDtos.UserPatchDto>(userPatchDto);
                var patchedUser = await _userRepository.PatchUserAsync(userId, user);
                return _mapper.Map<UserDtos.UserResponseDto>(patchedUser); // Retorna o usuário modificado
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("User not found"); // Lança exceção se não encontrar
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}"); // Lança exceção em caso de erro inesperado
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                await _userRepository.DeleteUserAsync(userId);
                return true; 
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("User not found");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}"); 
            }
        }
    }
}
