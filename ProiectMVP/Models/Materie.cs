using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Materie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<ElevMaterie> EleviMaterii { get; set; }
        public List<Profesor> Profesori { get; set; }
    }
}
