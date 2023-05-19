using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Clasa
    {
        public int Id { get; set; }
        public int An { get; set; }
        public string Initiala { get; set; }
        public Profesor ProfesorDiriginte { get; set; }
        public List<Elev> Elevi { get; set; }
    }
}
