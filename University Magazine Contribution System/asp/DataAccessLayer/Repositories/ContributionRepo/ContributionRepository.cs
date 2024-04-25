using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessLayer.Repositories.ContributionRepo
{
    public class ContributionRepository : IContributionRepository
    {
        private readonly UniMagDbContext _context;


        public ContributionRepository(UniMagDbContext context)
        {
            _context = context;
        }
        public async Task<Contribution> AddContributionAsync(string id, string title, string description, string type, string content)
        {

            var indexNumber = await Get_Maxnumber_ID(id);
            var contribtution = new Contribution();

            contribtution = await _context.contributions

                .Select(c => new Contribution
                {
                    StudentID = id,
                    Title = title,
                    Description = description,
                    Content = content,
                    Type = type,
                    ContributionID = id + "CTB" + (indexNumber + 1),
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
             }).ToListAsync();
        }
        public async Task<Contribution> UpdateAsync(string id, string title, string description, string type, string content)
        {
            var contributions = await GetByIdAsync(id);
            var indexNumber = contributions.Number_Id;
            contributions.Content = content;
            contributions.Title = title;
            contributions.Type = type;
            contributions.Description = description;
            contributions.LastUpdateDate = DateTime.UtcNow.ToLocalTime();
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


        private async Task<int> Get_Maxnumber_ID(string studentId)
        {
            int indexNumber=0;
            try
            {
                 indexNumber = _context.contributions
                    .Where(c => c.StudentID == studentId)
                    .Max(c => c.Number_Id);
            }
            catch {
                indexNumber = 1;
            }




            return indexNumber;
            
        }

        public async Task<Comment> SetComment(string user_id, string contributionId, string comment)
        {
            var contribution = await GetByIdAsync(contributionId);
            if ( contribution == null )
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
            return comments;
        }


    }
}



