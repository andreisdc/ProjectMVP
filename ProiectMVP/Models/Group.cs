using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public int Year { get; set; }
    public int ClassMasterId { get; set; }
    public Teacher ClassMaster { get; set; }
    public List<GroupCourse> GroupCourses { get; set; }
    public List<Student> Students { get; set; }
}