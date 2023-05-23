using System.Collections.Generic;

public class Semester
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; internal set; }
    public List<StudentSubject> StudentSubjects { get; set; }
}