using System.Collections.Generic;

namespace ProiectMVP.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<Subject> Subjects { get; set; }
        public bool Master { get; set; }
        public Class ClassMaster { get; set; }
        public int ClassMasterId { get; internal set; }
    }
}
