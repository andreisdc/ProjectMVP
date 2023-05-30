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
using ProiectMVP.Views.AdminViews;
using ProiectMVP.Views.StudentViews;
using ProiectMVP.Views.TeacherViews;

namespace ProiectMVP.ViewModels;

public class AuthenticationViewModel : BaseViewModel
{
    protected AppDbContext _dbContext;

    private string _username;
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

    private string _password;
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

    private string _errorMessage;
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

    private bool _isErrorVisible;
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
        var resultedUser = _dbContext.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

        if (resultedUser != null)
        {
            if (resultedUser.Role == UserRole.Admin)
            {
                var mainView = new AdminView(this._dbContext, resultedUser);
                mainView.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainView;
            }
            else if (resultedUser.Role == UserRole.Teacher)
            {
                var mainView = new TeacherView(this._dbContext, resultedUser);
                mainView.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainView;
            }
            else if (resultedUser.Role == UserRole.Student)
            {
                var mainView = new StudentView(this._dbContext, resultedUser);
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