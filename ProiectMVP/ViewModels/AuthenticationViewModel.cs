using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ProiectMVP.Data;
using ProiectMVP.Models;
using ProiectMVP.Service;
using ProiectMVP.Views;
using ProiectMVP.Views.Admin;
using ProiectMVP.Views.Student;
using ProiectMVP.Views.Teacher;

namespace ProiectMVP.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel
    {
        protected AppDbContext _dbContext;

        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isErrorVisible;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(IsErrorVisible));
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                OnPropertyChanged(nameof(IsErrorVisible));
            }
        }

        public bool IsLoginEnabled => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        public ICommand LoginCommand => new RelayCommand(Login);

        public AuthenticationViewModel(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.ErrorMessage = string.Empty;
        }

        private void Login(object parameter)
        {
            var result = _dbContext.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (result != null)
            {
                if (result.Role == UserRole.Admin)
                {
                    var mainView = new AdminView();
                    mainView.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = mainView;
                }
                else if (result.Role == UserRole.Professor)
                {
                    var mainView = new TeacherView();
                    mainView.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = mainView;
                }
                else if (result.Role == UserRole.Student)
                {
                    var mainView = new StudentView();
                    mainView.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = mainView;
                }
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
    }
}
