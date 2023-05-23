using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class ProfessorUser : Users
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
