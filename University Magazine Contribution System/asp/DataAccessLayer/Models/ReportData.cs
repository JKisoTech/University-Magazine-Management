using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ReportData
    {
        public string FacultyName { get; set; }
        public int Year { get; set; }
        public int TotalContributions { get; set; }
        public int TotalStudents { get; set; }
        public double PercentageContributions { get; set; }
    }
}
