using System;
using System.Windows;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.TeacherViewModels;

public class AddStudentGradeViewModel : BaseViewModel
{
    private int _value = -1;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged(nameof(Value));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

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

    private bool _isThesis = false;
    public bool IsThesis
    {
        get => _isThesis;
        set
        {
            _isThesis = value;
            OnPropertyChanged(nameof(IsThesis));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    private bool _hasThesis = false;
    public bool HasThesis
    {
        get => _hasThesis;
        set
        {
            _hasThesis = value;
            OnPropertyChanged(nameof(HasThesis));
        }
    }

    public ICommand AddCommand => new RelayCommand(Add, CanAdd);
    public ICommand CloseCommand => new RelayCommand(Close);

    public AddStudentGradeViewModel()
    {
    }

    private bool CanAdd(object parameter) =>
        (_value != -1) &&
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