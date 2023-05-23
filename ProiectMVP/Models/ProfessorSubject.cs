using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class ProfessorSubject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Professor Professor { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
