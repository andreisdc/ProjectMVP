using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ProiectMVP.Views;
using ProiectMVP.Views.Admin;


namespace ProiectMVP.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand ChangeViewCommand { get; }

        public MainWindowViewModel()
        {
            ChangeViewCommand = new RelayCommand(ChangeView);
        }

        public void ChangeView(object parameter)
        {
            var windowView = new MainWindowView();
            var mainWindowViewModel = (MainWindowViewModel)windowView.DataContext;
            AdminView newWindow = new AdminView();
            newWindow.Show();
            //MainWindow.instance.Close();
            try
            {
                Application.Current.MainWindow?.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
