using System;
using System.Windows;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.TeacherViewModels;

public class AddStudentAbsenceViewModel : BaseViewModel
{
    private DateTime _date = DateTime.Now;
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    private string _semester = string.Empty;
    public string Semester
    {
        get => _semester;
        set
        {
            _semester = value;
            OnPropertyChanged(nameof(Semester));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    public ICommand AddCommand => new RelayCommand(Add, CanAdd);
    public ICommand CloseCommand => new RelayCommand(Close);

    public AddStudentAbsenceViewModel()
    {
    }

    private bool CanAdd(object parameter) =>
        (!string.IsNullOrWhiteSpace(_semester));

    private static void Add(object parameter)
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