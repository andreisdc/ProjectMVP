using System.Collections.Generic;
using ProiectMVP.Models;

public class Teacher
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public List<TeacherCourse> ProfessorSubjects { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
