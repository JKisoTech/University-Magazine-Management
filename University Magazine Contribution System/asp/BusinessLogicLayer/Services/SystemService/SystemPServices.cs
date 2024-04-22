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
    public class SystemPServices : ISystemPServices
    {
        private readonly ISystemPRepository _systempRepository;
        private readonly IMapper _mapper;

        public SystemPServices(ISystemPRepository systempRepository, IMapper mapper)
        {
            _systempRepository = systempRepository;
            _mapper = mapper;
        }

        public async Task<SystemParameterDTO> get_submitDate(string parameterName)
        {
            var systemEntity = await _systempRepository.Get_Parameter(parameterName);
            return _mapper.Map<SystemParameterDTO>(systemEntity);
        }

        public async Task<SystemParameterDTO> get_completeDate(string parameterName)
        {
            var systemEntity = await _systempRepository.Get_Parameter(parameterName);
            return _mapper.Map<SystemParameterDTO>(systemEntity);
        }
    }
}
