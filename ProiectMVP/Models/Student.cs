using System.Collections.Generic;
using ProiectMVP.Models;

public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public List<StudentSubject> StudentSubjects { get; set; }
    public StudentUser StudentUser { get; set; }
}