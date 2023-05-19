using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models
{
    public class Semestru
    {
        public int Id { get; set; }
        public string Valoare { get; set; }
        public int MaterieId { get; set; }
        public int Nota { get; set; }
        public Materie Materie { get; internal set; }
    }
}
