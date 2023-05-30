using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProiectMVP.Data;
using ProiectMVP.Models;
using ProiectMVP.Views;

namespace ProiectMVP.ViewModels.StudentViewModels;

public class StudentViewModel : BaseViewModel
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

    public ICommand LogOutCommand => new RelayCommand(LogOut);

    public StudentViewModel(AppDbContext dbContext, User user)
    {
        this._dbContext = dbContext;
        this._loggedInUser = user;
    }

    public void LogOut(object paramater)
    {
        var mainView = new AuthenticationView(this._dbContext);
        mainView.Show();
        Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainView;
    }
}