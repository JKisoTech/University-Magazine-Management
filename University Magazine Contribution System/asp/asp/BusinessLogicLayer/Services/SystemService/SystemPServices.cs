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

        public async Task<DateTime?> get_submitDate(string parameterName)
        {
            var systemEntity = await _systempRepository.Get_Parameter(parameterName);
            if (systemEntity != null && DateTime.TryParse(systemEntity.Value, out DateTime submitDate))
            {
                return submitDate;
            }
            return null;
        }

        public async Task<DateTime?> get_completeDate(string parameterName)
        {
            var systemEntity = await _systempRepository.Get_Parameter(parameterName);
            if (systemEntity != null && DateTime.TryParse(systemEntity.Value, out DateTime completeDate))
            {
                return completeDate;
            }
            return null;
        }

        public async Task<Dictionary<string, int>> Dashboard()
        {
            var result = await _systempRepository.Dashboard();

            return result;
        }
    }
}
