using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.ContributionRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddContributionAync(ContributionsDTO contributionsDTO)
        {
            
            var title = contributionsDTO.Title; 
            var description = contributionsDTO.Description;
            var content = contributionsDTO.Content;
            var type = contributionsDTO.Type;
            var contributionEntity = _mapper.Map<Contribution>(contributionsDTO);
            await _contributionRepository.AddContributionAsync(contributionEntity ,title, description, content, type);

        }

        public async Task<List<ContributionsDTO>> GetContribution()
        {
            var contributionEntity = await _contributionRepository.GetAllAsync();
            return _mapper.Map<List<ContributionsDTO>>(contributionEntity);
        }

        public async Task UpdateContribution(ContributionsDTO contributionsDTO)
        {
            var existingConribution = await _contributionRepository.GetByIdAsync(contributionsDTO.ContributionID);

            if (existingConribution != null)
            {
                _mapper.Map(contributionsDTO, existingConribution);
                await _contributionRepository.UpdateAsync(existingConribution);
            }
        }

        public async Task DeactiveContribution(ContributionsDTO contributionsDTO)
        {
            var id = contributionsDTO.ContributionID;
            await _contributionRepository.GetByIdAsync(id);
        }

        //public async Task SubmitContribution(int id)
        //{
        //    var contribution = await _contributionRepository.GetByIdAsync(id);
        //    if (contribution.Status == "Saved")
        //    {
        //        throw new Exception("Contribution cannot be submitted in current state.");
        //    }
        //    if (contribution.Image != null)
        //    {

        //        var temporaryImagePath = Path.Combine(_configuration["TemporaryImagesPath"], contribution.Image);
        //        if (System.IO.File.Exists(temporaryImagePath))
        //        {

        //            var newImagePath = await UpdateImageStorageAsync(temporaryImagePath);
        //            contribution.Image = newImagePath.Replace(_configuration["TemporaryImagesPath"], "");
        //        }


        //        contribution.Status = "Submitted";
        //        contribution.SubmissionDate = DateTime.UtcNow;
        //        await _contributionRepository.UpdateAsync(contribution);
        //    }
        //}

            //public async Task CancelSubmission(int id)
            //{
            //    var contribution = await _contributionRepository.GetByIdAsync(id);
            //    if (contribution == null)
            //    {
            //        throw new Exception("Contribution not found.");
            //    }

            //    if (contribution.Status != "Submitted")
            //    {
            //        throw new Exception("Contribution cannot be canceled in current state.");
            //    }

            //    contribution.Status = "Canceled";

            //    await _contributionRepository.UpdateAsync(contribution);
            //}

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

