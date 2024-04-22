
using AutoMapper;
using Azure;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.ContributionRepo;
using GemBox.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.ContributionService
{
    public class ContributionServices : IContributionServices
    {
        private readonly IContributionRepository _contributionRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ContributionServices(IContributionRepository contributionRepository, IMapper mapper, IConfiguration configuration)
        {
            _contributionRepository = contributionRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ContributionsDTO> AddContributionAync(string id, string content, string title, IFormFile type, string description)
        {
            var filename = await WriteFile(type);
            var contributionDTO = new ContributionsDTO
            {
                Title = title,
                Content = content,
                Description = description,
                Type = filename
            };
            await _contributionRepository.AddContributionAsync(id, title, description, filename, content);
            _mapper.Map<ContributionsDTO>(contributionDTO);
            return contributionDTO;
        }

        public async Task<List<ContributionsDTO>> GetContribution()
        {
            var contributionEntity = await _contributionRepository.GetAllAsync();
            return _mapper.Map<List<ContributionsDTO>>(contributionEntity);
        }
        public async Task<ContributionsDTO> GetContent(string id)
        {
            
            var contributionEntity = await _contributionRepository.GetByIdAsync(id);
            

            return _mapper.Map<ContributionsDTO>(contributionEntity);
        }

        public async Task SetStatus(string id, int status)
        {
            var contributionEntity = await _contributionRepository.SetStatus(id, status);
            _mapper.Map<ContributionsDTO>(contributionEntity);
        }
        public async Task<ContributionsDTO> UpdateContribution(string id, string content, string title, IFormFile type, string description)
        {
            var newContribution = await _contributionRepository.GetByIdAsync(id);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "ContributionFiles");
            var oldpath = Path.Combine(filepath, newContribution.Type);
            if (!Directory.Exists(oldpath))
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
            var filename = await WriteFile(type);
            newContribution.ContributionID = id;
            newContribution.Title = title;
            newContribution.Content = content;
            newContribution.Type = filename;
            newContribution.Description = description;

            await _contributionRepository.UpdateAsync(id, content, title, filename, description);
            return _mapper.Map<ContributionsDTO>(newContribution);

        }

        public async Task<int> check_SubmitDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            DateTime submit_duedate = new DateTime(2024, 4, 30);
            if (currentDate <= submit_duedate)
            {
                return 0;
            }
            return 1;
        } 
        public async Task<int> check_CompleteDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            DateTime complete_duedate = new DateTime(2024, 4, 30);
            if (currentDate <= complete_duedate)
            {
                return 0;
            }
            return 1;
        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "ContributionFiles");
            try
            {
                var extension = Path.GetExtension(filename).ToLowerInvariant();
                filename = Path.GetFileName(file.FileName)+ extension;
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(filepath, filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            catch (Exception ex) { }
            return filename;
        }

        public async Task ConvertDocxToPDF(string id)
        {
            var existContribution = await _contributionRepository.GetByIdAsync(id);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(),"ContributionFiles");
            var wordpath = Path.Combine(filepath, existContribution.Type);
            if (System.IO.File.Exists(wordpath))
            {
                var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFFiles");
                var pdfName =  Path.ChangeExtension(wordpath, "pdf");
                var pdfFilePath = Path.Combine(pdfPath, pdfName);
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                ComponentInfo.FreeLimitReached += (eventSender, args) => args.FreeLimitReachedAction
                    = FreeLimitReachedAction.ContinueAsTrial;
                var document = DocumentModel.Load(wordpath);
                document.Save(pdfFilePath);

            }
       

        }

    }
}