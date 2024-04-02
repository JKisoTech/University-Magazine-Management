using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class User
    {
        
        [Key]
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int Role { get; set; }
        public string? FacultyID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.Date;
        public List<User_Faculty> user_Faculties { get; set; }
    }

}
