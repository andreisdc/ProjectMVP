using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ProiectMVP.Models;

public class Teacher
{
    public int Id { get; set; }
    public List<TeacherCourse> TeacherCourses { get; set; }
    public Group Group { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
