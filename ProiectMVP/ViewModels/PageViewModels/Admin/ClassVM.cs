using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProiectMVP.Models;


namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class ClassVM : BaseViewModel
	{
		public ICommand EditModeCommand { get; }
		public ICommand DeleteModeCommand { get; }
		public ICommand InsertModeCommand { get; }

		private readonly PageModel _pageModel;

		public ClassVM()
		{
			EditModeCommand = new RelayCommand(EditMode);
			DeleteModeCommand = new RelayCommand(DeleteMode);
			InsertModeCommand = new RelayCommand(InsertMode);
			_pageModel = new PageModel();
		}

		public void EditMode(object parameter)
		{

		}

		public void DeleteMode(object parameter)
		{

		}
		public void InsertMode(object parameter)
		{

		}
	}
}
