using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public List<Materie> Materii { get; set; }
        public bool Diriginte { get; set; }
        public Clasa ClasaDiriginte { get; set; }
        public int ClasaDiriginteId { get; internal set; }
    }
}
