using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
        public Subject Subject { get; internal set; }
    }
}
