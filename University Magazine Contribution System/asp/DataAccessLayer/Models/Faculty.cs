using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Faculty
    {
        [Key]
        public string FacultyID { get; set; }
        public string FacultyName { get; set; }
        public List<User_Faculty> user_Faculties { get; set; }
    }
}
