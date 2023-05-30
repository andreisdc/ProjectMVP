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
    ///     The group at which the user is class master.
    /// </summary>
    private Group? _group;
    public Group? Group
    {
        get => _group;
        set
        {
            _group = value;
            OnPropertyChanged(nameof(Group));
            OnPropertyChanged(nameof(IsGroupSelected));
        }
    }

    public bool IsGroupSelected => Group != null;

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

            if (value != null)
            {
                _courseStudyMaterials = value.StudyMaterials.ToList();
                _students = value.GroupCourses
                    .Select(gc => gc.Group.Students)
                    .SelectMany(s => s)
                    .ToList();
                OnPropertyChanged(nameof(CourseStudyMaterials));
                OnPropertyChanged(nameof(Students));
            }
        }
    }
    public bool IsCourseSelected => SelectedCourse != null;

    /// <summary>
    ///     The list of study materials for the selected course.
    /// </summary>
    private List<StudyMaterial> _courseStudyMaterials;
    public List<StudyMaterial> CourseStudyMaterials
    {
        get => _courseStudyMaterials;
        set
        {
            _courseStudyMaterials = value;
            OnPropertyChanged(nameof(CourseStudyMaterials));
        }
    }

    private StudyMaterial? _selectedCourseStudyMaterial;
    public StudyMaterial? SelectedCourseStudyMaterial
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

            if (value != null)
            {
                _studentGrades = value.Grades.ToList();
                _studentAverages = value.Averages.ToList();
                _studentAbsences = value.Absences.ToList();
                OnPropertyChanged(nameof(StudentGrades));
                OnPropertyChanged(nameof(StudentAverages));
                OnPropertyChanged(nameof(StudentAbsences));
            }
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

    private void ReloadCourses()
    {
        this.Courses = this.Group!.GroupCourses
            .Select(gc => gc.Course)
            .ToList();
        this.SelectedCourse = null;
    }

    public ClassMasterViewModel(AppDbContext dbContext, Teacher teacher)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = teacher;
        this.Group = this._dbContext.Groups
            .Include(g => g.Students)
            .Include(g => g.GroupCourses)
            .FirstOrDefault(g => g.ClassMasterId == teacher.Id);
        if (this.Group != null) this.ReloadCourses();
    }
}