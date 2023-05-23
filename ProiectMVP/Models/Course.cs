using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ProiectMVP.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public int Year { get; set; }
    public bool HasThesis { get; set; }
    public List<GroupCourse> GroupCourses { get; set; }
    public List<TeacherCourse> TeacherCourses { get; set; }
    public List<StudyMaterial> StudyMaterials { get; set; }
    public List<Absence> Absences { get; set; }
    public List<Grade> Grades { get; set; }
}