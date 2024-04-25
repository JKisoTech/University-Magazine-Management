using DataAccessLayer.Data;
using DataAccessLayer.Models;
using MailKit.Security;
using Microsoft.Exchange.WebServices.Data;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.SystemRepo
{
    public class SystemPRepository : ISystemPRepository
    {
        private readonly UniMagDbContext _context;
        private readonly IConfiguration _config;
        public SystemPRepository(UniMagDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
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


        public async Task<Dictionary<string, int>> Dashboard()
        {
            var totalContributions = await _context.contributions.CountAsync();

            var facultyContributions = await _context.contributions
                 .Where(c => c.Status == 3) // Filter by Contribution Status 
                 .Join(_context.faculty, // Join with the Faculty table
                     c => c.student.FacultyID,
                     f => f.FacultyID,
                     (c, f) => new // Project to an anonymous type with both entities
                     {
                         Contribution = c,
                         Faculty = f
                     })
                 .GroupBy(cf => cf.Faculty) // Group by Faculty entity from the join
                 .Select(group => new // Project a new anonymous type
                 {
                     Faculty = group.Key.FacultyName, // Access FacultyName from the Faculty entity
                     NumOfC = group.Count() // Count contributions within each group
                 })
                 .ToListAsync();

            var result = new Dictionary<string, int>
            {
                { "TotalContributions", totalContributions }
            };

            if (facultyContributions != null && facultyContributions.Any())
            {
                foreach (var fc in facultyContributions)
                {
                    result.Add($"NumOfC_{fc.Faculty}", fc.NumOfC);
                }
            }

            return result;
        }

        public async Task<int> SendEmail(string _sender, string _receiver, string title, string content)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_sender));
            email.To.Add(MailboxAddress.Parse(_receiver));
            email.Subject = title;
            email.Body = new TextPart(TextFormat.Html) { Text = $"<p>Dear {_context.Users.Where(u => u.LoginName == _receiver).Select(u => u.FullName).FirstOrDefault()},<br><br>You have received a comment from {_sender} regarding your application. Please look at it.<br><br>Sincerely,<br>{_sender}</p>" }; ;

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            return 0;

       
        }


        public async Task<List<ReportData>> GetReportData()
        {
            return await _context.contributions
                .Where(c => c.student.FacultyID!= null)
                .Join(_context.Students, c => c.StudentID, s => s.StudentID, (c, s) => new {Contribution =c, Student =s})
                .Join(_context.faculty, s => s.Student.FacultyID, f => f.FacultyID, (s, f) => new { FacultyName = f.FacultyName, Contribution = s.Contribution, Student = s.Student})
                .GroupBy(cf => new { cf.FacultyName, cf.Contribution.SubmissionDate.Year })
                .Select(g => new ReportData
                {
                    FacultyName = g.Key.FacultyName,
                    Year = g.Key.Year,
                    TotalContributions = g.Count(),
                    TotalStudents = g.Select(x => x.Student.StudentID).Distinct().Count(),
                    PercentageContributions = Math.Round(g.Count() / (double)_context.contributions.Count() * 100, 2)
                })
                .ToListAsync();
        }

        public async Task<List<ReportDataWithoutComment>> GetContributionsWithoutCommentsReport()
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-14);

            return await _context.contributions
                .Where(c => c.Comments.Count == 0 && c.SubmissionDate < cutoffDate)
                .Join(_context.Students, c => c.StudentID, s => s.StudentID, (c, s) => new { Contribution = c, Student = s })
                .Join(_context.faculty, s => s.Student.FacultyID, f => f.FacultyID, (s, f) => new { FacultyName = f.FacultyName, Contribution = s.Contribution, Student = s.Student })
                .GroupBy(cf => new { cf.FacultyName, cf.Contribution.SubmissionDate.Year, cf.Student.StudentName })
                .Select(g => new ReportDataWithoutComment
                {
                    FacultyName = g.Key.FacultyName,
                    Year = g.Key.Year,
                    ContributorName = g.Key.StudentName,
                    Title = g.FirstOrDefault().Contribution.Title
                })
                .ToListAsync();
        }
    }
}

