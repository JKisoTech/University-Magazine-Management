using AutoMapper;
using Azure;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.ContributionRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public async Task<ContributionsDTO> AddContributionAync(string id,string content, string title, IFormFile type, string description)
        {
            var filename = await WriteFile(type);
                var contributionDTO = new ContributionsDTO
                {
                    ContributionID = id,
                    Title = title,
                    Content = content,
                    Description = description,
                    Type = filename
                };
                await _contributionRepository.AddContributionAsync(id,title, description, content, filename);
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

        public async Task SetStatus(string id,int  status)
        {
            var contributionEntity = await _contributionRepository.SetStatus(id, status);
            _mapper.Map<ContributionsDTO>(contributionEntity);
        }
        public async Task<ContributionsDTO> UpdateContribution(string id, string content, string title, IFormFile type, string description)
        {
            var filename = await WriteFile(type);
            var contributionEntity = await _contributionRepository.GetByIdAsync(id);  
                await _contributionRepository.UpdateAsync(id, content, title, filename, description);
                return _mapper.Map<ContributionsDTO>(contributionEntity);

        }

        public async Task DeactiveContribution(ContributionsDTO contributionsDTO)
        {
            var id = contributionsDTO.ContributionID;
            await _contributionRepository.GetByIdAsync(id);
        }


        public async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "ContributionFiles");
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = file.FileName;
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "ContributionFiles", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
            }
            catch (Exception ex) { }
            return filename;
        }

        public async Task<string> UpdateImageStorageAsync(string temporaryImagePath)
            {

                var imageBytes = await System.IO.File.ReadAllBytesAsync(temporaryImagePath);

                var newImagePath = Path.Combine(_configuration["PermanentImagesPath"], Path.GetRandomFileName() + Path.GetExtension(temporaryImagePath));
                System.IO.File.WriteAllBytes(newImagePath, imageBytes);

                System.IO.File.Delete(temporaryImagePath);

                return newImagePath;
            }

            public async Task<string> SaveImageAsync(IFormFile imageFile)
            {

                if (imageFile != null && imageFile.Length > 0)
                {

                    var allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
                    if (!allowedExtensions.Contains(Path.GetExtension(imageFile.FileName).ToLower()))
                    {
                        throw new Exception("Invalid image format. Only JPG, JPEG, and PNG allowed.");
                    }


                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                    var fullPath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    return fileName;
                }

                return null;
            }
        }
    }

