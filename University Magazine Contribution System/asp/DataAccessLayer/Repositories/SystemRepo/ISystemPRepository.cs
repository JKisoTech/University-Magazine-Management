using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SystemRepo
{
    public interface ISystemPRepository
    {
        public Task<SystemParameter> Get_Parameter(string parameterName);

        public Task<int> SendEmail(string _sender, string _receiver, string title, string content);
        public Task<Dictionary<string, int>> Dashboard();
        public Task<List<ReportData>> GetReportData();
        public Task<List<ReportDataWithoutComment>> GetContributionsWithoutCommentsReport();
    }
}
