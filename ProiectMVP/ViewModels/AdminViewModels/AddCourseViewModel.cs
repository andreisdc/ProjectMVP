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

    public ICommand AddCommand => new RelayCommand(Add, CanAdd);
    public ICommand CloseCommand => new RelayCommand(Close);

    public AddCourseViewModel()
    {
    }

    private bool CanAdd(object parameter) =>
        !string.IsNullOrWhiteSpace(_name);

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