using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
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

        public async Task<SystemParameter> Get_Parameter(string parameterName)
        {
            return await _systempRepository.Get_Parameter(parameterName);
        }

        public async Task<Dictionary<string, int>> Dashboard()
        {
            var result = await _systempRepository.Dashboard();

            return result;
        }

        public async Task<List<ReportData>> GetReportData()
        {
            var report = await _systempRepository.GetReportData();
            return report;
        }

        public async Task<List<ReportDataWithoutComment>> GetContributionsWithoutCommentsReport()
        {
            var report = await _systempRepository.GetContributionsWithoutCommentsReport();
            return report;
        }


    }
}
