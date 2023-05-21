using System.Collections.Generic;

namespace ProiectMVP.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Group { get; set; }
        public Professor ClassMaster { get; set; }
        public List<Student> Students { get; set; }
    }
}
