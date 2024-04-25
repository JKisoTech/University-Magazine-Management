using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SystemRepo
{
    public class SystemPRepository : ISystemPRepository
    {
        private readonly UniMagDbContext _context;

        public SystemPRepository(UniMagDbContext context)
        {
            _context = context;
        }
        public async Task<SystemParameter> Get_Parameter(string parameterName)
        {
            return _context.systemParameters.FirstOrDefault(p => p.Name == parameterName);
        }
    }
}
