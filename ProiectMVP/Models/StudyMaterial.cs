using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models;

public class StudyMaterial
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public byte[] Content { get; set; }
}
