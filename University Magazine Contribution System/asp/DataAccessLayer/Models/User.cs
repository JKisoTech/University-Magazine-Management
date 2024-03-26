using System.ComponentModel.DataAnnotations;

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
        public string Faculty {  get; set; }

    }

}
