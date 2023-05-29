using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProiectMVP.Data;
using ProiectMVP.Models;

namespace ProiectMVP.ViewModels.AdminViewModels;

public class EditCourseViewModel : BaseViewModel
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(CanSave));
        }
    }

    public ICommand SaveCommand => new RelayCommand(Save, CanSave);
    public ICommand CloseCommand => new RelayCommand(Close);

    public EditCourseViewModel()
    {
    }

    private bool CanSave(object parameter) =>
        !string.IsNullOrWhiteSpace(_name);

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