using ProiectMVP.Data;
using ProiectMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ProiectMVP.ViewModels.AdminViewModels;

public class EditStudentViewModel : BaseViewModel
{
    private string _firstName = string.Empty;
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    private string _lastName = string.Empty;
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    private string _username = string.Empty;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    private int _groupId = -1;
    public int GroupId
    {
        get => _groupId;
        set
        {
            _groupId = value;
            OnPropertyChanged(nameof(GroupId));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    public ICommand SaveCommand => new RelayCommand(Save, CanSave);
    public ICommand CloseCommand => new RelayCommand(Close);

    public EditStudentViewModel()
    {
    }

    private bool CanSave(object parameter) =>
        !string.IsNullOrWhiteSpace(_firstName) &&
        !string.IsNullOrWhiteSpace(_lastName) &&
        !string.IsNullOrWhiteSpace(_username) &&
        !string.IsNullOrWhiteSpace(_password) &&
        (_groupId != -1);

    private static void Save(object parameter)
    {
        if (parameter is Window window)
        {
            window.DialogResult = true;
            window.Close();
        }
    }

    private static void Close(object parameter)
    {
        if (parameter is Window window)
        {
            window.DialogResult = false;
            window.Close();
        }
    }
}