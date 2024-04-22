using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.SystemService
{
    public interface ISystemPServices
    {
        public Task<SystemParameterDTO> get_submitDate(string parameterName);
        public Task<SystemParameterDTO> get_completeDate(string parameterName);
    }
}
