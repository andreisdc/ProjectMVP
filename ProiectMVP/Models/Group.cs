using ProiectMVP.Models;
using System.Collections.Generic;

public class Group
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public int ClassMasterId { get; set; }
    public Teacher ClassMaster { get; set; }
    public List<Student> Students { get; set; }
    public List<Course> Subjects { get; set; }
}