using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Repositories.SystemRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.SystemService
{
    public class SystemServices : ISystemServices
    {
        private readonly SystemRepository _systemRepository;
        private readonly Mapper _mapper;

        public SystemServices(SystemRepository systemRepository, Mapper mapper)
        {
            _systemRepository = systemRepository;
            _mapper = mapper;
        }

        public async Task<SystemParameterDTO> get_submitDate(string parameterName)
        {
            var systemEntity = await _systemRepository.Get_Parameter(parameterName);
            return _mapper.Map<SystemParameterDTO>(systemEntity);
        }

        public async Task<SystemParameterDTO> get_completeDate(string parameterName)
        {
            var systemEntity = await _systemRepository.Get_Parameter(parameterName);
            return _mapper.Map<SystemParameterDTO>(systemEntity);
        }
    }
}
