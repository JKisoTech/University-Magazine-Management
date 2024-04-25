using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

      

        public async Task<int> check_SubmitDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            var submitDate = await Get_Parameter("SUBMIT_DATE");
            DateTime submit_duedate = Convert.ToDateTime( submitDate);
            if (currentDate <= submit_duedate)
            {
                return 0;
            }
            return 1;
        }
        public async Task<int> check_CompleteDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            var completeDate = await Get_Parameter("COMPLETE_DATE");
            DateTime complete_duedate = Convert.ToDateTime(completeDate);
            if (currentDate <= complete_duedate)
            {
                return 0;
            }
            return 1;
        }

     

        public async Task<int> SendEmail(string _sender, string _receiver, string title, string content)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_sender);
            mail.To.Add(_receiver);

            mail.Subject = title;
            mail.Body = content;

            var smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential();
            
            return 0;
        }
    }
}

