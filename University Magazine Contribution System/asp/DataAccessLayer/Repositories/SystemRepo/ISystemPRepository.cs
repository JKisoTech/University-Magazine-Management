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
    }
}
