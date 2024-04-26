using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class UserDTO
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string FullName { get; set; }
        
        public string Password { get; set; } 

        public bool Status { get; set; }
        [Required]
        public int  Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.Date;
        public string? Email { get; set; }

        public string? FacultyID { get; set; }
    }
}
