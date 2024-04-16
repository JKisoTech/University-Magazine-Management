using AutoMapper;
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

        public async Task<List<StudentDTO>> GetAllStudentAsync()
        {
            var studentEntity = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(studentEntity);
        }

        public async Task<StudentDTO> GetStudentByIdAsync(string _loginName)
        {
            var studentEntity = await _studentRepository.GetbyIDAsync(_loginName) ;
            return _mapper.Map<StudentDTO>(studentEntity);
        }

        public Task UpdateStudentAsync(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
