using ProiectMVP.Models;
using System.Collections.Generic;

public class StudentCourse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Course Course { get; set; }
    public List<Grade> Grades { get; set; }
    public List<Absence> Absences { get; set; }
    public int SemesterId { get; set; }
    public Semester Semester { get; set; }
}