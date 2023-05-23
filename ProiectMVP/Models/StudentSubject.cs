using ProiectMVP.Models;
using System.Collections.Generic;

public class StudentSubject
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public List<Grade> Grades { get; set; }
    public List<Absence> Absences { get; set; }
}