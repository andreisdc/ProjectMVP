using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProiectMVP.Data;
using ProiectMVP.Models;
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

    private List<Course> _teacherCourses;
    public List<Course> TeacherCourses
    {
        get => _teacherCourses;
        set
        {
            _teacherCourses = value;
            OnPropertyChanged(nameof(TeacherCourses));
        }
    }

    private Course? _selectedTeacherCourse;
    public Course? SelectedTeacherCourse
    {
        get => _selectedTeacherCourse;
        set
        {
            _selectedTeacherCourse = value;
            OnPropertyChanged(nameof(SelectedTeacherCourse));
            OnPropertyChanged(nameof(IsTeacherCourseSelected));
        }
    }
    public bool IsTeacherCourseSelected => SelectedTeacherCourse != null;

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
            OnPropertyChanged(nameof(SelectedGroup));
            OnPropertyChanged(nameof(IsGroupSelected));
        }
    }
    public bool IsGroupSelected => SelectedGroup != null;

    public ICommand LogOutCommand => new RelayCommand(LogOut);
    public ICommand AddStudentCommand => new RelayCommand(AddStudent);
    public ICommand EditStudentCommand => new RelayCommand(EditStudent, CanActivateStudentCommand);
    public ICommand DeleteStudentCommand => new RelayCommand(DeleteStudent, CanActivateStudentCommand);
    public ICommand AddTeacherCommand => new RelayCommand(AddTeacher);
    public ICommand EditTeacherCommand => new RelayCommand(EditTeacher, CanActivateTeacherCommand);
    public ICommand DeleteTeacherCommand => new RelayCommand(DeleteTeacher, CanActivateTeacherCommand);
    public ICommand AssignCourseToTeacherCommand => new RelayCommand(AssignCourseToTeacher);
    public ICommand RemoveCourseFromTeacherCommand => new RelayCommand(RemoveCourseFromTeacher);
    public ICommand AddCourseCommand => new RelayCommand(AddCourse);
    public ICommand EditCourseCommand => new RelayCommand(EditCourse, CanActivateCourseCommand);
    public ICommand DeleteCourseCommand => new RelayCommand(DeleteCourse, CanActivateCourseCommand);
    public ICommand AddGroupCommand => new RelayCommand(AddGroup);
    public ICommand EditGroupCommand => new RelayCommand(EditGroup, CanActivateGroupCommand);
    public ICommand DeleteGroupCommand => new RelayCommand(DeleteGroup, CanActivateGroupCommand);

    public AdminViewModel(AppDbContext dbContext, User user)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = user;
        this.Students = dbContext.Students.ToList();
        this.Teachers = dbContext.Teachers.ToList();
        this.Courses = dbContext.Courses.ToList();
        this.Groups = dbContext.Groups.ToList();
    }

    public void LogOut(object paramater)
    {
        throw new NotImplementedException();
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
        }
    }

    public void DeleteStudent(object parameter)
    {
        if (SelectedStudent == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this student?", "Delete student", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            this._dbContext.Students.Remove(new Student
            {
                Id = SelectedStudent.Id
            });
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
        }
    }

    public void AssignCourseToTeacher(object parameter)
    {
        if (SelectedTeacher == null) return;
        if (SelectedCourse == null) return;

        this._dbContext.TeacherCourses.Add(new TeacherCourse
        {
            TeacherId = SelectedTeacher.Id,
            CourseId = SelectedCourse.Id
        });
        this._dbContext.SaveChanges();
    }

    public void RemoveCourseFromTeacher(object parameter)
    {
        if (SelectedTeacher == null) return;
        if (SelectedTeacherCourse == null) return;

        this._dbContext.TeacherCourses.Remove(new TeacherCourse
        {
            TeacherId = SelectedTeacher.Id,
            CourseId = SelectedTeacherCourse.Id
        });
        this._dbContext.SaveChanges();
    }

    public void AddCourse(object parameter)
    {
        var newView = new AddCourseView();
        var newViewModel = (AddCourseViewModel)newView.DataContext;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            this._dbContext.Courses.Add(new Course
            {
                Name = newViewModel.Name
            });
            this._dbContext.SaveChanges();
        }
    }

    public bool CanActivateCourseCommand(object parameter) => SelectedCourse != null;

    public void EditCourse(object parameter)
    {
        if (SelectedCourse == null) return;

        var newView = new EditCourseView();
        var newViewModel = (EditCourseViewModel)newView.DataContext;
        newViewModel.Name = SelectedCourse.Name;

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedCourse.Name = newViewModel.Name;

            this._dbContext.Courses.Update(SelectedCourse);
            this._dbContext.SaveChanges();
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
                Name = newViewModel.Name
            });
            this._dbContext.SaveChanges();
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

        if (newView.ShowDialog().GetValueOrDefault())
        {
            SelectedGroup.Name = newViewModel.Name;
            SelectedGroup.Specialization = newViewModel.Specialization;
            SelectedGroup.Year = newViewModel.Year;

            this._dbContext.Groups.Update(SelectedGroup);
            this._dbContext.SaveChanges();
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
        }
    }
}