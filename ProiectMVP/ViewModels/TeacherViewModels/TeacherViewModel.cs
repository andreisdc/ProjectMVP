using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProiectMVP.Data;
using ProiectMVP.Models;
using ProiectMVP.ViewModels.AdminViewModels;
using ProiectMVP.Views;
using ProiectMVP.Views.AdminViews;
using ProiectMVP.Views.TeacherViews;

namespace ProiectMVP.ViewModels.TeacherViewModels;

public class TeacherViewModel : BaseViewModel
{
    protected AppDbContext _dbContext;

    private User _loggedInUser;
    public User LoggedInUser
    {
        get => _loggedInUser;
        set
        {
            _loggedInUser = value;
            OnPropertyChanged(nameof(LoggedInUser));
        }
    }

    private Teacher? _classMaster;
    public Teacher? ClassMaster
    {
        get => _classMaster;
        set
        {
            _classMaster = value;
            OnPropertyChanged(nameof(ClassMaster));
        }
    }

    public bool IsClassMaster => ClassMaster != null;

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
                CourseStudyMaterials = value.StudyMaterials.ToList();
                Students = this._dbContext.GroupCourses
                    .Include(gc => gc.Group)
                    .Select(gc => gc.Group.Students)
                    .SelectMany(s => s)
                    .Include(s => s.User)
                    .Include(s => s.Group)
                    .Include(s => s.Grades)
                    .Include(s => s.Averages)
                    .Include(s => s.Absences)
                    .ToList();
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
                StudentGrades = value.Grades.ToList();
                StudentAverages = value.Averages.ToList();
                StudentAbsences = value.Absences.ToList();
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

    public ICommand LogOutCommand => new RelayCommand(LogOut);
    public ICommand OpenClassMasterDashboardCommand => new RelayCommand(OpenClassMasterDashboard, CanActivateClassMasterDashboardCommand);
    public ICommand AddCourseStudyMaterialCommand => new RelayCommand(AddCourseStudyMaterial);
    public ICommand RemoveCourseStudyMaterialCommand => new RelayCommand(RemoveCourseStudyMaterial);
    public ICommand AddStudentAbsenceCommand => new RelayCommand(AddStudentAbsence);
    public ICommand CancelStudentAbsenceCommand => new RelayCommand(CancelStudentAbsence);
    public ICommand AddStudentGradeCommand => new RelayCommand(AddStudentGrade);
    public ICommand CancelStudentGradeCommand => new RelayCommand(CancelStudentGrade);
    public ICommand CalculateStudentAverageCommand => new RelayCommand(CalculateStudentAverage);
    public ICommand CancelStudentAverageCommand => new RelayCommand(CancelStudentAverage);

    private void ReloadCourses()
    {
        int teacherId = this.LoggedInUser.Teacher.Id;
        this.Courses = this._dbContext.Courses
            .Where(c => c.TeacherId == teacherId)
            .Include(c => c.GroupCourses)
            .Include(c => c.StudyMaterials)
            .ToList();
        this.SelectedCourse = null;
    }

    private void ReloadStudents()
    {
        this.Students = this._dbContext.Students
            .Where(s => s.GroupId == this.SelectedCourse!.GroupCourses.First().GroupId)
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Grades)
            .Include(s => s.Averages)
            .Include(s => s.Absences)
            .ToList();
        this.SelectedStudent = null;
    }

    public TeacherViewModel(AppDbContext dbContext, User user)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = user;
        this.ClassMaster = user.Teacher;
        this.ReloadCourses();
    }

    private void LogOut(object parameter)
    {
        var mainView = new AuthenticationView(this._dbContext);
        mainView.Show();
        Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainView;
    }

    private bool CanActivateClassMasterDashboardCommand(object parameter) => ClassMaster != null;

    private void OpenClassMasterDashboard(object parameter)
    {
        var newView = new ClassMasterView(this._dbContext, this.ClassMaster);
        var newViewModel = (ClassMasterViewModel)newView.DataContext;

        newView.Show();
    }

    private void AddCourseStudyMaterial(object parameter)
    {
        if (SelectedCourse == null) return;

        var newStudyMaterial = new StudyMaterial();

        var openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            newStudyMaterial.Name = openFileDialog.FileName;
            newStudyMaterial.Extension = Path.GetExtension(openFileDialog.FileName);
            newStudyMaterial.Content = File.ReadAllBytes(openFileDialog.FileName);
            newStudyMaterial.CourseId = SelectedCourse.Id;

            this._dbContext.StudyMaterials.Add(newStudyMaterial);
            this._dbContext.SaveChanges();

            this.ReloadCourses();
        }
    }

    private void RemoveCourseStudyMaterial(object parameter)
    {
        if (SelectedCourseStudyMaterial == null) return;

        this._dbContext.StudyMaterials.Remove(SelectedCourseStudyMaterial);
        this._dbContext.SaveChanges();

        this.ReloadCourses();
    }

    private void AddStudentAbsence(object parameter)
    {
        if (SelectedStudent == null) return;
        if (SelectedCourse == null) return;

        var newView = new AddStudentAbsenceView();
        var newViewModel = (AddStudentAbsenceViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            this._dbContext.Absences.Add(new Absence
            {
                StudentId = SelectedStudent.Id,
                CourseId = SelectedCourse.Id,
                Date = newViewModel.Date,
                Semester = newViewModel.Semester,
                IsMotivated = false,
            });
            this._dbContext.SaveChanges();
            
            this.ReloadStudents();
        }
    }

    private void CancelStudentAbsence(object parameter)
    {
        if (SelectedStudentAbsence == null) return;

        if (SelectedStudentAbsence.IsMotivated)
        {
            MessageBox.Show("Absence already motivated.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var result = MessageBox.Show("Are you sure you want to motivate this absence?", "Motivate", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            SelectedStudentAbsence.IsMotivated = true;

            this._dbContext.Absences.Update(SelectedStudentAbsence);
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    private void AddStudentGrade(object parameter)
    {
        if (SelectedStudent == null) return;
        if (SelectedCourse == null) return;

        var newView = new AddStudentGradeView();
        var newViewModel = (AddStudentGradeViewModel)newView.DataContext;
        newViewModel.HasThesis = this.SelectedCourse.HasThesis;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            var existingThesis = this._dbContext.Grades
                .FirstOrDefault(g =>
                    g.StudentId == SelectedStudent.Id &&
                    g.CourseId == SelectedCourse.Id &&
                    g.Semester == newViewModel.Semester &&
                    g.IsThesis == true &&
                    g.IsCanceled == false);
            if (existingThesis != null)
            {
                MessageBox.Show("A thesis grade for this course and student already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this._dbContext.Grades.Add(new Grade
            {
                StudentId = SelectedStudent.Id,
                CourseId = SelectedCourse.Id,
                Value = newViewModel.Value,
                Date = newViewModel.Date,
                Semester = newViewModel.Semester,
                IsThesis = newViewModel.IsThesis,
                IsCanceled = false,
            });
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    private void CancelStudentGrade(object parameter)
    {
        if (SelectedStudentGrade == null) return;

        if (SelectedStudentGrade.IsCanceled)
        {
            MessageBox.Show("Grade already cancelled.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var result = MessageBox.Show("Are you sure you want to cancel this grade?", "Cancel grade", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            SelectedStudentGrade.IsCanceled = true;

            this._dbContext.Grades.Update(SelectedStudentGrade);
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    private void CalculateStudentAverage(object parameter)
    {
        if (SelectedStudent == null) return;
        if (SelectedCourse == null) return;

        var result = MessageBox.Show("Are you sure you want to calculate the average?", "Calculate", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            var grades = SelectedCourse.Grades
                .Where(g => g.StudentId == SelectedStudent.Id)
                .Where(g => !g.IsCanceled)
                .Where(g => !g.IsThesis)
                .ToList();

            if (!grades.Any())
            {
                MessageBox.Show("The student does not have any grades!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var thesisGrade = SelectedCourse.Grades
                .Where(g => g.StudentId == SelectedStudent.Id)
                .Where(g => !g.IsCanceled)
                .FirstOrDefault(g => g.IsThesis);

            if (thesisGrade == null)
            {
                MessageBox.Show("The student does not have a thesis grade!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var average = (3 * grades.Average(g => g.Value) + thesisGrade.Value) / 4;

            this._dbContext.Averages.Add(new Average
            {
                StudentId = SelectedStudent.Id,
                CourseId = SelectedCourse.Id,
                Value = average,
                Date = DateTime.Now,
                IsCanceled = false,
            });
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    private void CancelStudentAverage(object parameter)
    {
        if (SelectedStudentAverage == null) return;

        var result = MessageBox.Show("Are you sure you want to cancel this average?", "Cancel average", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            SelectedStudentAverage.IsCanceled = true;

            this._dbContext.Averages.Update(SelectedStudentAverage);
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }
}