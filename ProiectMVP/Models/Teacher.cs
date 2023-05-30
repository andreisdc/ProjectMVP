using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models;

public class Teacher
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Group Group { get; set; }
    public List<Course> Courses { get; set; }
}
