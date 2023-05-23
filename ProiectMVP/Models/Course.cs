using System.Collections.Generic;
using ProiectMVP.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasThesis { get; set; }
    public List<StudentCourse> StudentSubjects { get; set; }
    public List<TeacherCourse> ProfessorSubjects { get; set; }
    public List<StudyMaterial> StudyMaterials { get; set; }
}