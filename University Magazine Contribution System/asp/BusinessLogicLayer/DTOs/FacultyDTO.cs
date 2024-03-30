using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class FacultyDTO
    {
        [Required]
        public string FacultyID { get; set; }
        [Required]
        public string FacultyName { get; set; }

    }
}
