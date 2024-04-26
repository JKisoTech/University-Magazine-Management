using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class ContributionsDTO
    {
        [Required]
        public string ContributionID { get; set; }
        public string StudentID { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public int Expired { get; set; }

        public bool AggreeOnTerm { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    }
}
