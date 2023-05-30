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

public class AddCourseViewModel : BaseViewModel
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    private string _specialization = string.Empty;
    public string Specialization
    {
        get => _specialization;
        set
        {
            _specialization = value;
            OnPropertyChanged(nameof(Specialization));
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    private int _year = -1;
    public int Year
    {
        get => _year;
        set
        {
            _year = value;
            OnPropertyChanged(nameof(Year));
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
            OnPropertyChanged(nameof(CanAdd));
        }
    }

    public ICommand AddCommand => new RelayCommand(Add, CanAdd);
    public ICommand CloseCommand => new RelayCommand(Close);

    public AddCourseViewModel()
    {
    }

    private bool CanAdd(object parameter) =>
        !string.IsNullOrWhiteSpace(this._name) &&
        !string.IsNullOrWhiteSpace(this._specialization) &&
        (this._year != -1);

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