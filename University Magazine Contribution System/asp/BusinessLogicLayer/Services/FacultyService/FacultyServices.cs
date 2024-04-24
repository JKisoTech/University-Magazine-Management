using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.FacultyRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.FacultyService
{
    public class FacultyServices : IFacultyServices
    {
        private readonly IFacultyRepository _repository;
        private readonly IMapper _mapper;

        public FacultyServices(IFacultyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<FacultyDTO> GetFacultyByIdAsync(string id)
        {
            var facultyEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<FacultyDTO>(facultyEntity);
        }


        public async Task<List<FacultyDTO>> GetAllFacultyAsync()
        {
            var facultyEntity = await _repository.GetFacultyAsync();
            return _mapper.Map<List<FacultyDTO>>(facultyEntity);
        }

        public async Task AddFacultyAsync(FacultyDTO facultyDTO)
        {
            var facultyEntity = _mapper.Map<Faculty>(facultyDTO);
            await _repository.AddFacultyAsync(facultyEntity);
        }

        public async Task UpdateFacultyAsync(FacultyDTO facultyDTO)
        {
            var existingFaculty = await _repository.GetByIdAsync(facultyDTO.FacultyID);

            if (existingFaculty != null)
            {
                _mapper.Map(facultyDTO, existingFaculty);
                await _repository.UpdateFacultyAsync(existingFaculty);
            }
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteFacultyAsync(id);
        }
    }
}
