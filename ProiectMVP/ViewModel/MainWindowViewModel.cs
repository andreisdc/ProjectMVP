using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProiectMVP.Command.ChangeViewCommand;

namespace ProiectMVP.ViewModel
{
	public class MainWindowViewModel: BaseViewModel
	{
		private BaseViewModel _selectedViewModel;

		public BaseViewModel SelectedViewModel
		{
			get { return _selectedViewModel;}
			set { _selectedViewModel = value; }
		}

		public ICommand ChangeView { get; set; }

		public MainWindowViewModel()
		{
			ChangeView = new ChangeViewCommand(this);
		}

	}
}
