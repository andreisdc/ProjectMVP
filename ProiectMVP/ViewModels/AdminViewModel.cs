using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProiectMVP.ViewModels
{
    internal class AdminViewModel : BaseViewModel
    {
        public ICommand AddStudentCommand => new RelayCommand(AddStudent);
        public ICommand EditStudentCommand => new RelayCommand(EditStudent);
        public ICommand DeleteStudentCommand => new RelayCommand(DeleteStudent);
        public ICommand AddTeacherCommand => new RelayCommand(AddTeacher);
        public ICommand EditTeacherCommand => new RelayCommand(EditTeacher);
        public ICommand DeleteTeacherCommand => new RelayCommand(DeleteTeacher);
        public ICommand AddCourseCommand => new RelayCommand(AddCourse);
        public ICommand EditCourseCommand => new RelayCommand(EditCourse);
        public ICommand DeleteCourseCommand => new RelayCommand(DeleteCourse);

        public AdminViewModel()
        {
        
        }

        public void AddStudent(object parameter)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(object parameter)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(object parameter)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(object parameter)
        {
            throw new NotImplementedException();
        }

        public void EditTeacher(object parameter)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacher(object parameter)
        {
            throw new NotImplementedException();
        }

        public void AddCourse(object parameter)
        {
            throw new NotImplementedException();
        }

        public void EditCourse(object parameter)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
