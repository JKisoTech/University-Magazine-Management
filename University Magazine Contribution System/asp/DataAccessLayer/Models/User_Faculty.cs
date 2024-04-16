using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class User_Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uSID { get; set; }
        [ForeignKey("Faculty")]
        public string FacultyId { get; set; }
        [ForeignKey("User")]
        public string LoginName { get; set; }

        public Faculty faculty { get; set; }

        public User user { get; set; }

       
    }
}
