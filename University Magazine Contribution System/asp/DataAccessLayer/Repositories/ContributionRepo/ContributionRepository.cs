using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.SystemRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessLayer.Repositories.ContributionRepo
{
    public class ContributionRepository : IContributionRepository
    {
        private readonly UniMagDbContext _context;
        private readonly ISystemPRepository _systemPRepository;


        public ContributionRepository(UniMagDbContext context, ISystemPRepository systemPRepository)
        {
            _context = context;
            _systemPRepository = systemPRepository;
        }
        public async Task<Contribution> AddContributionAsync(string id, string title, string description, string type, string content, int indexNumber, string academy)
        {
            var contribtution = new Contribution();
            contribtution = await _context.contributions

                .Select(c => new Contribution
                {
                    StudentID = id,
                    Title = title,
                    Description = description,
                    Content = content,
                    Type = type,
                    ContributionID = id + "_" + academy + "_" + (indexNumber + 1),
                    Number_Id = indexNumber + 1,
                }).FirstOrDefaultAsync();

            await _context.AddAsync(contribtution);
            await _context.SaveChangesAsync();


            return contribtution;
        }

        public async Task<Contribution> GetByIdAsync(string id)
        {
            var contribution = await _context.contributions
             .Where(c => c.ContributionID == id)
             .Select(c => new Contribution
             {
                 ContributionID = c.ContributionID,
                 StudentID = c.StudentID,
                 Content = c.Content,
                 SubmissionDate = c.SubmissionDate,
                 LastUpdateDate = c.LastUpdateDate,
                 Published = c.Published,
                 AgreeOnTerm = c.AgreeOnTerm,
                 Description = c.Description,
                 Title = c.Title,
                 Type = c.Type,
                 Number_Id = c.Number_Id
             })
             .FirstOrDefaultAsync();

            return contribution;
        }

        public async Task<IEnumerable<Comment>> GetComment(string id)
        {
            var comements = await _context.comments
                .Where(c => c.ContributionID == id)
                .Select(c => new Comment
                {
                    CoordinatorID = c.CoordinatorID,
                    ContributionID = c.ContributionID,
                    Comments = c.Comments,
                    CommentDate = c.CommentDate,
                }).ToListAsync();
            return comements;
        }
        public async Task<IEnumerable<Contribution>> GetAllAsync()
        {
            return await _context.contributions
             .Select(c => new Contribution
             {
                 ContributionID = c.ContributionID,
                 StudentID = c.StudentID,
                 Content = c.Content,
                 SubmissionDate = c.SubmissionDate,
                 LastUpdateDate = c.LastUpdateDate,
                 Published = c.Published,
                 AgreeOnTerm = c.AgreeOnTerm,
                 Description = c.Description,
                 Title = c.Title,
                 Type = c.Type,
                 Status = c.Status,
                 Expired = c.Expired
             }).ToListAsync();
        }
        public async Task<Contribution> UpdateAsync(string id, string title, string description, string type, string content)
        {
            var contributions = await GetByIdAsync(id);
            var expired = contributions.Expired;
            var indexNumber = contributions.Number_Id;
            contributions.Content = content;
            contributions.Title = title;
            contributions.Type = type;
            contributions.Description = description;
            contributions.LastUpdateDate = DateTime.UtcNow.ToLocalTime();
            contributions.Expired = expired;
            _context.contributions.Update(contributions);
            await _context.SaveChangesAsync();
            return contributions;
        }

        public async Task<Contribution> SetStatus(string id, int status)
        {

            var contribution = await _context.contributions.FindAsync(id);
            contribution.Status = status;
            contribution.LastUpdateDate = DateTime.UtcNow.ToLocalTime();
            _context.contributions.Update(contribution);
            await _context.SaveChangesAsync();
            return contribution;
        }
        public async Task<Contribution> SetExpired()
        {

            var expired_date = await _systemPRepository.Get_Parameter("EXPIRED_DATE");

            var current_date = DateTime.UtcNow.Date;

            var contribution = await GetAllAsync();
            int nCount = contribution.Count();
            for (int i = 0; i < nCount; i++)
            {

                var firstContribution = contribution.ElementAt(i);
                if (firstContribution.Status != 3)
                {
                    if (current_date > Convert.ToDateTime(expired_date.Value))
                    {
                        firstContribution.Expired = 1;
                        _context.contributions.Update(firstContribution);
                        await _context.SaveChangesAsync();
                        
                    }
                    firstContribution.Expired = 0;
                    _context.contributions.Update(firstContribution);
                    await _context.SaveChangesAsync();
                } 
            }

            return null;
        }


        public async Task<int> Get_Maxnumber_ID(string studentId)
        {
            int indexNumber = 0;
            try
            {
                indexNumber = _context.contributions
                   .Where(c => c.StudentID == studentId)
                   .Max(c => c.Number_Id);
            }
            catch
            {
                indexNumber = 1;
            }




            return indexNumber;

        }

        public async Task<Comment> SetComment(string user_id, string contributionId, string title, string comment)
        {
            var contribution = await GetByIdAsync(contributionId);

            string coordinatorEmail = _context.Users
                .Where(s => s.LoginName == user_id)
                .Select(s => s.Email)
                .FirstOrDefault();

            string studentid = _context.contributions
                .Where(s => s.ContributionID == contributionId)
                .Select(s => s.StudentID)
                .FirstOrDefault();

            string studentEmail = _context.Users
                .Where(s => s.LoginName == studentid)
                .Select(s => s.Email)
                .FirstOrDefault();

            

            if (contribution == null)
            {
                throw new ArgumentException("Invalid Contribution ID");
            }
            var comments = new Comment
            {
                CoordinatorID = user_id,
                ContributionID = contributionId,
                Comments = comment,
                CommentDate = DateTime.UtcNow.ToLocalTime(),
            };

            _context.comments.Add(comments);
            await _context.SaveChangesAsync();
            var sendEmail = await _systemPRepository.SendEmail(coordinatorEmail, studentEmail, title, comment);
            return comments;
        }


    }
}



