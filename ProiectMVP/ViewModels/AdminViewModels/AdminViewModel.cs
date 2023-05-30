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
using ProiectMVP.Views.AdminViews;

namespace ProiectMVP.ViewModels.AdminViewModels;

public class AdminViewModel : BaseViewModel
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

    private List<Teacher> _teachers;
    public List<Teacher> Teachers
    {
        get => _teachers;
        set
        {
            _teachers = value;
            OnPropertyChanged(nameof(Teachers));
        }
    }

    private Teacher? _selectedTeacher;
    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            _selectedTeacher = value;
            OnPropertyChanged(nameof(SelectedTeacher));
            OnPropertyChanged(nameof(IsTeacherSelected));
        }
    }
    public bool IsTeacherSelected => SelectedTeacher != null;

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

    private List<Group> _groups;
    public List<Group> Groups
    {
        get => _groups;
        set
        {
            _groups = value;
            OnPropertyChanged(nameof(Groups));
        }
    }

    private Group? _selectedGroup;
    public Group? SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            _selectedGroup = value;
            _groupCourses = _selectedGroup?.GroupCourses.Select(gc => gc.Course).ToList() ?? new();
            OnPropertyChanged(nameof(SelectedGroup));
            OnPropertyChanged(nameof(IsGroupSelected));
        }
    }
    public bool IsGroupSelected => SelectedGroup != null;

    private List<Course> _groupCourses;
    public List<Course> GroupCourses
    {
        get => _groupCourses;
        set
        {
            _groupCourses = value;
            OnPropertyChanged(nameof(GroupCourses));
        }
    }

    private Course? _selectedGroupCourse;
    public Course? SelectedGroupCourse
    {
        get => _selectedGroupCourse;
        set
        {
            _selectedGroupCourse = value;
            OnPropertyChanged(nameof(SelectedGroupCourse));
            OnPropertyChanged(nameof(IsGroupCourseSelected));
        }
    }
    public bool IsGroupCourseSelected => SelectedGroupCourse != null;

    public ICommand LogOutCommand => new RelayCommand(LogOut);
    public ICommand AddStudentCommand => new RelayCommand(AddStudent);
    public ICommand EditStudentCommand => new RelayCommand(EditStudent, CanActivateStudentCommand);
    public ICommand DeleteStudentCommand => new RelayCommand(DeleteStudent, CanActivateStudentCommand);
    public ICommand AddTeacherCommand => new RelayCommand(AddTeacher);
    public ICommand EditTeacherCommand => new RelayCommand(EditTeacher, CanActivateTeacherCommand);
    public ICommand DeleteTeacherCommand => new RelayCommand(DeleteTeacher, CanActivateTeacherCommand);
    public ICommand AddCourseCommand => new RelayCommand(AddCourse);
    public ICommand EditCourseCommand => new RelayCommand(EditCourse, CanActivateCourseCommand);
    public ICommand DeleteCourseCommand => new RelayCommand(DeleteCourse, CanActivateCourseCommand);
    public ICommand AddGroupCommand => new RelayCommand(AddGroup);
    public ICommand EditGroupCommand => new RelayCommand(EditGroup, CanActivateGroupCommand);
    public ICommand DeleteGroupCommand => new RelayCommand(DeleteGroup, CanActivateGroupCommand);
    public ICommand AssignCourseToGroupCommand => new RelayCommand(AssignCourseToGroup);
    public ICommand RemoveCourseFromGroupCommand => new RelayCommand(RemoveCourseFromGroup);

    private void ReloadStudents()
    {
        this.Students = this._dbContext.Students
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Absences)
            .Include(s => s.Grades)
            .ToList();
        this.SelectedStudent = null;
    }

    private void ReloadTeachers()
    {
        this.Teachers = this._dbContext.Teachers
            .Include(t => t.User)
            .Include(t => t.Group)
            .ToList();
        this.SelectedTeacher = null;
    }

    private void ReloadCourses()
    {
        this.Courses = this._dbContext.Courses.ToList();
        this.SelectedCourse = null;
    }

    private void ReloadGroups()
    {
        this.Groups = this._dbContext.Groups
            .Include(g => g.ClassMaster)
            .Include(g => g.GroupCourses)
            .Include(g => g.Students)
            .ToList();
        this.SelectedGroup = null;
    }

    public AdminViewModel(AppDbContext dbContext, User user)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = user;
        this.ReloadStudents();
        this.ReloadTeachers();
        this.ReloadCourses();
        this.ReloadGroups();
    }

    public void LogOut(object paramater)
    {
        var mainView = new AuthenticationView(this._dbContext);
        mainView.Show();
        Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainView;
    }

    public void AddStudent(object parameter)
    {
        var newView = new AddStudentView();
        var newViewModel = (AddStudentViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            var newUser = new User
            {
                FirstName = newViewModel.FirstName,
                LastName = newViewModel.LastName,
                Username = newViewModel.Username,
                Password = newViewModel.Password,
                Role = UserRole.Student,
            };

            this._dbContext.Students.Add(new Student
            {
                User = newUser,
                GroupId = newViewModel.GroupId,
            });
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    public bool CanActivateStudentCommand(object parameter) => SelectedStudent != null;

    public void EditStudent(object parameter)
    {
        if (SelectedStudent == null) return;

        var newView = new EditStudentView();
        var newViewModel = (EditStudentViewModel)newView.DataContext;
        newViewModel.FirstName = SelectedStudent.User.FirstName;
        newViewModel.LastName = SelectedStudent.User.LastName;
        newViewModel.Username = SelectedStudent.User.Username;
        newViewModel.Password = SelectedStudent.User.Password;
        newViewModel.GroupId = SelectedStudent.GroupId;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedStudent.User.FirstName = newViewModel.FirstName;
            SelectedStudent.User.LastName = newViewModel.LastName;
            SelectedStudent.User.Username = newViewModel.Username;
            SelectedStudent.User.Password = newViewModel.Password;
            SelectedStudent.GroupId = newViewModel.GroupId;

            this._dbContext.Students.Update(SelectedStudent);
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    public void DeleteStudent(object parameter)
    {
        if (SelectedStudent == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this student?", "Delete student", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this._dbContext.Students.Remove(SelectedStudent);
            this._dbContext.SaveChanges();

            this.ReloadStudents();
        }
    }

    public void AddTeacher(object parameter)
    {
        var newView = new AddTeacherView();
        var newViewModel = (AddTeacherViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            var newUser = new User
            {
                FirstName = newViewModel.FirstName,
                LastName = newViewModel.LastName,
                Username = newViewModel.Username,
                Password = newViewModel.Password,
                Role = UserRole.Professor
            };

            this._dbContext.Teachers.Add(new Teacher
            {
                User = newUser,
            });
            this._dbContext.SaveChanges();

            this.ReloadTeachers();
        }
    }

    public bool CanActivateTeacherCommand(object parameter) => SelectedTeacher != null;

    public void EditTeacher(object parameter)
    {
        if (SelectedTeacher == null) return;

        var newView = new EditTeacherView();
        var newViewModel = (EditTeacherViewModel)newView.DataContext;
        newViewModel.FirstName = SelectedTeacher.User.FirstName;
        newViewModel.LastName = SelectedTeacher.User.LastName;
        newViewModel.Username = SelectedTeacher.User.Username;
        newViewModel.Password = SelectedTeacher.User.Password;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedTeacher.User.FirstName = newViewModel.FirstName;
            SelectedTeacher.User.LastName = newViewModel.LastName;
            SelectedTeacher.User.Username = newViewModel.Username;
            SelectedTeacher.User.Password = newViewModel.Password;

            this._dbContext.Teachers.Update(SelectedTeacher);
            this._dbContext.SaveChanges();

            this.ReloadTeachers();
        }
    }

    public void DeleteTeacher(object parameter)
    {
        if (SelectedTeacher == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this teacher?", "Delete teacher", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this._dbContext.Teachers.Remove(new Teacher
            {
                Id = SelectedTeacher.Id
            });
            this._dbContext.SaveChanges();

            this.ReloadTeachers();
        }
    }

    public void AddCourse(object parameter)
    {
        var newView = new AddCourseView();
        var newViewModel = (AddCourseViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            this._dbContext.Courses.Add(new Course
            {
                Name = newViewModel.Name,
                Specialization = newViewModel.Specialization,
                Year = newViewModel.Year,
                HasThesis = newViewModel.HasThesis,
            });
            this._dbContext.SaveChanges();

            this.ReloadCourses();
        }
    }

    public bool CanActivateCourseCommand(object parameter) => SelectedCourse != null;

    public void EditCourse(object parameter)
    {
        if (SelectedCourse == null) return;

        var newView = new EditCourseView();
        var newViewModel = (EditCourseViewModel)newView.DataContext;
        newViewModel.Name = SelectedCourse.Name;
        newViewModel.Specialization = SelectedCourse.Specialization;
        newViewModel.Year = SelectedCourse.Year;
        newViewModel.HasThesis = SelectedCourse.HasThesis;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedCourse.Name = newViewModel.Name;
            SelectedCourse.Specialization = newViewModel.Specialization;
            SelectedCourse.Year = newViewModel.Year;
            SelectedCourse.HasThesis = newViewModel.HasThesis;

            this._dbContext.Courses.Update(SelectedCourse);
            this._dbContext.SaveChanges();

            this.ReloadCourses();
        }
    }

    public void DeleteCourse(object parameter)
    {
        if (SelectedCourse == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this course?", "Delete course", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this._dbContext.Courses.Remove(new Course
            {
                Id = SelectedCourse.Id
            });
            this._dbContext.SaveChanges();

            this.ReloadCourses();
        }
    }

    public void AddGroup(object parameter)
    {
        var newView = new AddGroupView();
        var newViewModel = (AddGroupViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            this._dbContext.Groups.Add(new Group
            {
                Name = newViewModel.Name,
                Specialization = newViewModel.Specialization,
                Year = newViewModel.Year,
                ClassMasterId = newViewModel.ClassMasterId,
            });
            this._dbContext.SaveChanges();

            this.ReloadGroups();
        }
    }

    public bool CanActivateGroupCommand(object parameter) => SelectedGroup != null;

    public void EditGroup(object parameter)
    {
        if (SelectedGroup == null) return;

        var newView = new EditGroupView();
        var newViewModel = (EditGroupViewModel)newView.DataContext;
        newViewModel.Name = SelectedGroup.Name;
        newViewModel.Specialization = SelectedGroup.Specialization;
        newViewModel.Year = SelectedGroup.Year;
        newViewModel.ClassMasterId = SelectedGroup.ClassMasterId;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedGroup.Name = newViewModel.Name;
            SelectedGroup.Specialization = newViewModel.Specialization;
            SelectedGroup.Year = newViewModel.Year;
            SelectedGroup.ClassMasterId = newViewModel.ClassMasterId;

            this._dbContext.Groups.Update(SelectedGroup);
            this._dbContext.SaveChanges();

            this.ReloadGroups();
        }
    }

    public void DeleteGroup(object parameter)
    {
        if (SelectedGroup == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this group?", "Delete group", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this._dbContext.Groups.Remove(new Group
            {
                Id = SelectedGroup.Id
            });
            this._dbContext.SaveChanges();

            this.ReloadGroups();
        }
    }

    public void AssignCourseToGroup(object parameter)
    {
        if (SelectedGroup == null) return;
        if (SelectedCourse == null) return;

        this._dbContext.GroupCourses.Add(new GroupCourse
        {
            GroupId = SelectedGroup.Id,
            CourseId = SelectedCourse.Id
        });
        this._dbContext.SaveChanges();

        this.ReloadGroups();
    }

    public void RemoveCourseFromGroup(object parameter)
    {
        if (SelectedGroup == null) return;
        if (SelectedGroupCourse == null) return;

        this._dbContext.GroupCourses.Remove(new GroupCourse
        {
            GroupId = SelectedGroup.Id,
            CourseId = SelectedGroupCourse.Id
        });
        this._dbContext.SaveChanges();

        this.ReloadGroups();
    }
}