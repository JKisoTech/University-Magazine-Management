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
        public Task<StudentDTO> GetStudentByIDAsync(string id);

        public Task<List<StudentDTO>> GetAllStudentAsync();

    }
}
