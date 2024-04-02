using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.User;
using DataAccessLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UsersService
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserServices> _logger;

        public UserServices(IUserRepository userRepository, IMapper mapper, ILogger<UserServices> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
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

        public async Task AddUserAsync(UserDTO userDTO, string facultyID)
        {
            var userEntity = _mapper.Map<DataAccessLayer.Models.User>(userDTO);
            userEntity.Password = _userRepository.VerifyPasswordHash(userDTO.Password);

            await _userRepository.AddUserAsync(userEntity, facultyID);
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

        public async Task<UserDTO> AdminLogin(string _loginname, string _password)
        {
            var user = await _userRepository.GetUserByUsernameAndPassword(_loginname, _password);
            if (user == null || user.Role != 0)
            {
                return null;
            } else
            return _mapper.Map<UserDTO>(user);
        }


        public async Task<UserDTO> UserLogin(string _loginName, string _password)
        {
            var pass = _userRepository.VerifyPasswordHash(_password);
            var userEntity = await _userRepository.GetUserByUsernameAndPassword(_loginName, pass);
            
            return _mapper.Map<UserDTO>(userEntity); ;
        }



    }
}
