using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
