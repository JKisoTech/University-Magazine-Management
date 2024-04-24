using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Comment
    {
        [Key]
        public string CoordinatorID { get; set; }
        [ForeignKey("Contribution")]
        public string ContributionID { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
