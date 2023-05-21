using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProiectMVP.Models;
using ProiectMVP.View.Admin;
using ProiectMVP.View.Elev;
using ProiectMVP.View.Profesor;
using ProiectMVP.ViewModel;

namespace ProiectMVP.Command.ChangeViewCommand
{
	internal class ChangeViewCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;
		private MainWindowViewModel _viewModel;

		public ChangeViewCommand(MainWindowViewModel viewModel)
		{
			this._viewModel = viewModel;
		}

		public bool CanExecute(object? parameter)
		{
			return true;
		}
 
		public void Execute(object? parameter)
		{
			ElevView newWindow = new ElevView();
			newWindow.Show();
			MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
			mainWindow.Close();
			_viewModel.SelectedViewModel = new TeacherViewModel();
		}
	}
}
