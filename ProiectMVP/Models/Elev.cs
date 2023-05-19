using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Elev
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int ClasaId { get; set; }
        public Clasa Clasa { get; set; }
        public List<ElevMaterie> EleviMaterii { get; set; }
    }
}
