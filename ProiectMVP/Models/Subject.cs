using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
        public List<Professor> Professors { get; set; }
    }
}
