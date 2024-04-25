
using AutoMapper;
using Azure;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.SystemService;
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
        private readonly ISystemPServices _systemPServices;

        public ContributionServices(IContributionRepository contributionRepository, IMapper mapper, ISystemPServices systemPServices)
        {
            _contributionRepository = contributionRepository;
            _mapper = mapper;
            _systemPServices = systemPServices;
        }

        public async Task<ContributionsDTO> AddContributionAync(string id, string content, string title, IFormFile type, string description)
        {
            var filename = await WriteFile(type,id);
            var contributionDTO = new ContributionsDTO
            {
                Title = title,
                Content = content,
                Description = description,
                Type = filename,

                
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
            
            newContribution.ContributionID = id;
            newContribution.Title = title;
            newContribution.Content = content;

            var filename = await WriteFile(type,id);
            
            newContribution.Type = filename;
            newContribution.Description = description;

            await _contributionRepository.UpdateAsync(id, content, title, filename, description);
            return _mapper.Map<ContributionsDTO>(newContribution);

        }

        public async Task<CommentDTO> SetComment(string user_id, string contributionId, string comment)
        {
            var newComment = await _contributionRepository.SetComment(user_id, contributionId, comment);
            return _mapper.Map<CommentDTO>(newComment);
        }

        public async Task<int> check_SubmitDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            var submitDate = await _systemPServices.get_submitDate("SUBMIT_DATE");
            DateTime submit_duedate = submitDate.Value;
            if (currentDate <= submit_duedate)
            {
                return 0;
            }
            return 1;
        } 
        public async Task<int> check_CompleteDate()
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            var completeDate = await _systemPServices.get_completeDate("COMPLETE_DATE");
            DateTime complete_duedate = completeDate.Value;
            if (currentDate <= complete_duedate)
            {
                return 0;
            }
            return 1;
        }

        public async Task<string> WriteFile(IFormFile file, string id)
        {
  
            string filename = "";
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "ContributionFiles");
            try
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (extension == ".docx")
                {
                    filename = $"{id}{extension}";
                } else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    filename = $"{id}{extension}";
                }
                else
                {
                    throw new NotSupportedException("File format not supported.");
                }
               
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
            if (System.IO.File.Exists(wordpath) && Path.GetExtension(wordpath) == ".docx")
            {
                var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFFiles");
                var pdfName = $"{id}.pdf";
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