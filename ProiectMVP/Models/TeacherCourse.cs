using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Course Course { get; set; }
    }
}
