using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Phones { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }

        public ICollection<Contribution> Contributions { get; set;}

    }
}
