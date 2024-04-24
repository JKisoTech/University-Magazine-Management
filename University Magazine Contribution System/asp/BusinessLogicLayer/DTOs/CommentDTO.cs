using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CommentDTO
    {
        [Required]
        public string CoordinatorID { get; set; }
        [Required]
        public string ContributionID { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.UtcNow.Date;
    }
}
