using System.Collections.Generic;
using ProiectMVP.Models;

public class Professor
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public List<ProfessorSubject> ProfessorSubjects { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}