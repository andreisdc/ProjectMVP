using System.Collections.Generic;
using ProiectMVP.Models;

public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int ClassId { get; set; }
    public Group Group { get; set; }
    public List<StudentCourse> StudentSubjects { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

}
