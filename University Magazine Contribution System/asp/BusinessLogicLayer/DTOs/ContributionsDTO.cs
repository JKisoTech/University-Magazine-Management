using DataAccessLayer.Models;
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
        public int ContributionID { get; set; }
        public int StudentID { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }
        [Required]
        public List<Comment> Comments { get; set; }
        [Required]
        public string Image {  get; set; }
        [Required]
        public DateTime Published { get; set; }
        [Required]
        public bool AgreeOnTerm { get; set; }
        [Required]
        public string Expired { get; set; }
    }
}
