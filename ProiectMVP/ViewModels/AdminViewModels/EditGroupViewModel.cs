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

public class EditGroupViewModel : BaseViewModel
{
    private string _name = String.Empty;
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

    private string _specialization = String.Empty;
    public string Specialization
    {
        get => _specialization;
        set
        {
            _specialization = value;
            OnPropertyChanged(nameof(Specialization));
            OnPropertyChanged(nameof(CanSave));
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
            OnPropertyChanged(nameof(CanSave));
        }
    }

    public ICommand SaveCommand => new RelayCommand(Save, CanSave);
    public ICommand CloseCommand => new RelayCommand(Close);

    public EditGroupViewModel()
    {
    }

    private bool CanSave(object parameter) =>
        !string.IsNullOrWhiteSpace(this._name) &&
        !string.IsNullOrWhiteSpace(this._specialization) &&
        (this._year != -1);

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