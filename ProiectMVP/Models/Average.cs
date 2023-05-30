﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMVP.Models;

public class Average
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public double Value { get; set; }
    public DateTime Date { get; set; }
    public string Semester { get; set; }
    public bool IsCanceled { get; set; }
}