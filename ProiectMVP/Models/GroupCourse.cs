namespace ProiectMVP.Models;

public class GroupCourse
{ 
    public int Id { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}