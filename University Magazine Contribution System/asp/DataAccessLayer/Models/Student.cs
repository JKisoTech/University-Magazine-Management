using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Phones { get; set; }
        public string FacultyID { get; set; }
        public User user { get; set; }
        public ICollection<Contribution> Contributions { get; set;}

    }
}
