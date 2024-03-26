using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class User_Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        [ForeignKey("User")]
        public string LoginName { get; set; }
    }
}
