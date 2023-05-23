using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public int StudentSubjectId { get; set; }
        public StudentSubject StudentSubject { get; set; }
        public DateTime Date { get; set; }
        public string Semester { get; set; }
        public bool IsMotivated { get; set; }
    }
}
