using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.SystemService
{
    public interface ISystemPServices
    {
        public Task<SystemParameter> Get_Parameter(string parameterName);

        public Task<Dictionary<string, int>> Dashboard();
        public Task<List<ReportData>> GetReportData();
        public Task<List<ReportDataWithoutComment>> GetContributionsWithoutCommentsReport();
    }
}
