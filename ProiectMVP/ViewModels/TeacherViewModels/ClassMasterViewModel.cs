using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProiectMVP.Data;
using ProiectMVP.Models;
using ProiectMVP.Views;

namespace ProiectMVP.ViewModels.TeacherViewModels;

public class ClassMasterViewModel : BaseViewModel
{
    protected AppDbContext _dbContext;

    private Teacher _loggedInUser;
    public Teacher LoggedInUser
    {
        get => _loggedInUser;
        set
        {
            _loggedInUser = value;
            OnPropertyChanged(nameof(LoggedInUser));
        }
    }

    /// <summary>
    ///     The list of courses.
    /// </summary>
    private List<Course> _courses;
    public List<Course> Courses
    {
        get => _courses;
        set
        {
            _courses = value;
            OnPropertyChanged(nameof(Courses));
        }
    }

    private Course? _selectedCourse;
    public Course? SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            OnPropertyChanged(nameof(SelectedCourse));
            OnPropertyChanged(nameof(IsCourseSelected));
        }
    }
    public bool IsCourseSelected => SelectedCourse != null;

    /// <summary>
    ///     The list of study materials for the selected course.
    /// </summary>
    private List<Course> _courseStudyMaterials;
    public List<Course> CourseStudyMaterials
    {
        get => _courseStudyMaterials;
        set
        {
            _courseStudyMaterials = value;
            OnPropertyChanged(nameof(CourseStudyMaterials));
        }
    }

    private Course? _selectedCourseStudyMaterial;
    public Course? SelectedCourseStudyMaterial
    {
        get => _selectedCourseStudyMaterial;
        set
        {
            _selectedCourseStudyMaterial = value;
            OnPropertyChanged(nameof(SelectedCourseStudyMaterial));
            OnPropertyChanged(nameof(IsCourseStudyMaterialSelected));
        }
    }
    public bool IsCourseStudyMaterialSelected => SelectedCourseStudyMaterial != null;

    /// <summary>
    ///     The list of students.
    /// </summary>
    private List<Student> _students;
    public List<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            OnPropertyChanged(nameof(Students));
        }
    }

    private Student? _selectedStudent;
    public Student? SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;
            OnPropertyChanged(nameof(SelectedStudent));
            OnPropertyChanged(nameof(IsStudentSelected));
        }
    }
    public bool IsStudentSelected => SelectedStudent != null;

    /// <summary>
    ///     The list of grades for the selected student.
    /// </summary>
    private List<Grade> _studentGrades;
    public List<Grade> StudentGrades
    {
        get => _studentGrades;
        set
        {
            _studentGrades = value;
            OnPropertyChanged(nameof(StudentGrades));
        }
    }

    private Grade? _selectedStudentGrade;
    public Grade? SelectedStudentGrade
    {
        get => _selectedStudentGrade;
        set
        {
            _selectedStudentGrade = value;
            OnPropertyChanged(nameof(SelectedStudentGrade));
            OnPropertyChanged(nameof(IsStudentGradeSelected));
        }
    }
    public bool IsStudentGradeSelected => SelectedStudentGrade != null;

    /// <summary>
    ///     The list of absences for the selected student.
    /// </summary>
    private List<Absence> _studentAbsences;
    public List<Absence> StudentAbsences
    {
        get => _studentAbsences;
        set
        {
            _studentAbsences = value;
            OnPropertyChanged(nameof(StudentAbsences));
        }
    }

    private Absence? _selectedStudentAbsence;
    public Absence? SelectedStudentAbsence
    {
        get => _selectedStudentAbsence;
        set
        {
            _selectedStudentAbsence = value;
            OnPropertyChanged(nameof(SelectedStudentAbsence));
            OnPropertyChanged(nameof(IsStudentAbsenceSelected));
        }
    }

    public bool IsStudentAbsenceSelected => SelectedStudentAbsence != null;

    /// <summary>
    ///     The list of averages for the selected student.
    /// </summary>
    private List<Average> _studentAverages;
    public List<Average> StudentAverages
    {
        get => _studentAverages;
        set
        {
            _studentAverages = value;
            OnPropertyChanged(nameof(StudentAverages));
        }
    }

    private Average? _selectedStudentAverage;
    public Average? SelectedStudentAverage
    {
        get => _selectedStudentAverage;
        set
        {
            _selectedStudentAverage = value;
            OnPropertyChanged(nameof(SelectedStudentAverage));
            OnPropertyChanged(nameof(IsStudentAverageSelected));
        }
    }

    public bool IsStudentAverageSelected => SelectedStudentAverage != null;
    
    private void ReloadStudents()
    {
        this.Students = this._dbContext.Students
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Grades)
            .Include(s => s.Averages)
            .Include(s => s.Absences)
            .ToList();
        this.SelectedStudent = null;
    }

    private void ReloadCourses(int teacherId)
    {
        this.Courses = this._dbContext.Courses
            .Where(c => c.TeacherId == teacherId)
            .Include(c => c.GroupCourses)
            .Include(c => c.StudyMaterials)
            .Include(c => c.Absences)
            .Include(c => c.Grades)
            .Include(c => c.Averages)
            .ToList();
        this.SelectedCourse = null;
    }

    public ClassMasterViewModel(AppDbContext dbContext, Teacher teacher)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = teacher;
        this.ReloadCourses(teacher.Id);
    }
}