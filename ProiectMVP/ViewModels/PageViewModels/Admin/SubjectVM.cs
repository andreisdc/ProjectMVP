using ProiectMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class SubjectVM
	{

		public ICommand EditModeCommand { get; }
		public ICommand DeleteModeCommand { get; }
		public ICommand InsertModeCommand { get; }


		public readonly PageModel _pageModel;

		public SubjectVM()
		{
			_pageModel = new PageModel();
			EditModeCommand = new RelayCommand(EditMode);
			DeleteModeCommand = new RelayCommand(DeleteMode);
			InsertModeCommand = new RelayCommand(InsertMode);
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
