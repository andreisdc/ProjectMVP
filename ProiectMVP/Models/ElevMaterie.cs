using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class ElevMaterie
    {
        public int ElevId { get; set; }
        public Elev Elev { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
        public int Nota { get; set; }
        public bool Absent { get; set; }
        public DateTime Data { get; set; }
        public string Semestru { get; set; }
    }
}
