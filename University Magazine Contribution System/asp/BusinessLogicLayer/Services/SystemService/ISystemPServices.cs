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

        
    }
}
