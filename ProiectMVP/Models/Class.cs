using ProiectMVP.Models;
using System.Collections.Generic;

public class Class
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int ClassMasterId { get; set; }
    public Professor ClassMaster { get; set; }
    public List<Student> Students { get; set; }
    public List<Subject> Subjects { get; set; }
}