using System.Collections.Generic;

public class Professor
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public List<Subject> Subjects { get; set; }
}