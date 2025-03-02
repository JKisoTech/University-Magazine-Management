﻿using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.StudentService
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentServices(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task AddStudentAsync(StudentDTO studentDTO)
        {
            var studentEntity = _mapper.Map<Student>(studentDTO);
          
            await _studentRepository.AddAsync(studentEntity);
        }

        public Task DeactiveStudent(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentDTO>> GetAllStudentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDTO> GetStudentByIdAsync(string _loginName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
