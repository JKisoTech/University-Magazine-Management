using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Contribution
    {
        [Key]
        public string ContributionID { get; set; }
        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime LastUpdateDate { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime Published { get; set; }  
        public bool AgreeOnTerm { get; set; }



    
    }
}
