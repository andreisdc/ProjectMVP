using System.Collections.Generic;
using ProiectMVP.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasThesis { get; set; }
    public List<StudentSubject> StudentSubjects { get; set; }
    public List<ProfessorSubject> ProfessorSubjects { get; set; }
    public List<StudyMaterial> StudyMaterials { get; set; }
}