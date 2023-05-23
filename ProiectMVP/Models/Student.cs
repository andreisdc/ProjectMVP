using System.Collections.Generic;
using ProiectMVP.Models;

public class Student
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Absence> Absences { get; set; }
    public List<Grade> Grades { get; set; }

}
