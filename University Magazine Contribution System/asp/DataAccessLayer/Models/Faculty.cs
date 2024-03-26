using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public string Description {  get; set; }
    }
}
