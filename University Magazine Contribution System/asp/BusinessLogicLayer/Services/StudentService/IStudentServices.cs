using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.StudentService
{
    public interface IStudentServices
    {
        public Task<StudentDTO> GetStudentByIdAsync(string _loginName);

        public Task<List<StudentDTO>> GetAllStudentAsync();

        public Task AddStudentAsync(StudentDTO studentDTO);
        public Task UpdateStudentAsync(StudentDTO studentDTO);
        public Task DeactiveStudent(StudentDTO studentDTO);
    }
}
