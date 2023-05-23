using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class StudentUser : Users
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
