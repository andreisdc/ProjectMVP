using System.Collections.Generic;

public class Semester
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int SubjectId { get; set; }
    public Course Course { get; internal set; }
    public List<StudentCourse> StudentSubjects { get; set; }
}