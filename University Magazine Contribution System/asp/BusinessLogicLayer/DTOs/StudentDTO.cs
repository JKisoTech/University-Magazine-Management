using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class StudentDTO
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
       
        public int Phones { get; set; }
        [Required]
        public int FacultyID { get; set; }
    }
}
