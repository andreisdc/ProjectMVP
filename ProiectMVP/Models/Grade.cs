using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentSubjectId { get; set; }
        public StudentSubject StudentSubject { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Semester { get; set; }
    }
}
