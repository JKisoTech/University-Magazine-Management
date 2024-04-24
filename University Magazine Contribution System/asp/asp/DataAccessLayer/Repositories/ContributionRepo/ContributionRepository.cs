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
        public async Task<Contribution> AddContributionAsync(string id, string title, string description, string type,string content)
        {
            var contribution = new Contribution();
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.LoginName == id && u.Role == 1);
            if (existingUser == null)
            {
                existingUser = new Models.User
                {
                    LoginName = contribution.StudentID,
                    Role = 1,
                };
                _context.Users.Add(existingUser);
                await _context.SaveChangesAsync();
            }

            var contributions = new Contribution
            {
                StudentID = existingUser.LoginName,
                Title = title,
                Description = description,
                Content = content,
                Type = type,
                ContributionID = existingUser.LoginName + "CTB"
            };
            await _context.AddAsync(contributions);
            await _context.SaveChangesAsync();

            return contribution;

        }

 
        public async Task<Contribution> GetByIdAsync(string id)
        {
            return await _context.contributions.FirstOrDefaultAsync(u => u.ContributionID == id);
        }
        public async Task<IEnumerable<Contribution>> GetAllAsync()
        {
            return await _context.contributions.ToListAsync();
        }
        public async Task<Contribution> UpdateAsync(string id, string title, string description, string type, string content)
        {
            var contributions = await _context.contributions.FindAsync(id);
            contributions.Content = content;
            contributions.Title = title;
            contributions.Type = type;
            contributions.Description = description;
            contributions.LastUpdateDate = DateTime.UtcNow;
            _context.contributions.Update(contributions);
            await _context.SaveChangesAsync();
            return contributions;
        }

        public async Task<Contribution> SetStatus(string id, int status)
        {

            var contribution = await _context.contributions.FindAsync(id);
            contribution.Status = status;
            contribution.LastUpdateDate = DateTime.UtcNow;
            _context.contributions.Update(contribution);
            await _context.SaveChangesAsync();
            return contribution;
        }
        public async Task DeleteAsync(string id)
        {
            var contributionID = await GetByIdAsync(id);
            if (contributionID != null)
            {
                _context.contributions.Remove(contributionID);
                await _context.SaveChangesAsync();
            }
        }


    }
}

