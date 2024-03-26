using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.User;
using DataAccessLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UsersService
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByLoginNameAsync(string _loginName)
        {
            var userEntity = await _userRepository.GetByIdAsync(_loginName);
            return _mapper.Map<UserDTO>(userEntity);
        }

     
        public async Task<List<UserDTO>> GetAllUserAsync()
        {
            var userEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<List<UserDTO>>(userEntity);
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<DataAccessLayer.Models.User>(userDTO);
            await _userRepository.AddUserAsync(userEntity);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDTO.LoginName);

            if (existingUser != null)
            {
                _mapper.Map(userDTO, existingUser);
                await _userRepository.UpdateAsync(existingUser);
            }
        }

        public async Task DeleteAsync(string _loginName)
        {
            await _userRepository.DeleteAsync(_loginName);
        }
    }
}
