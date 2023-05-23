using ProiectMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.PageViewModels.Teacher
{
	internal class GradeVM
	{
		public readonly PageModel _pageModel;

		public ICommand InsertModeCommand { get; set; }
		public ICommand DeleteModeCommand { get; set; }
		public ICommand EditModeCommand { get; set; }

		public GradeVM()
		{
			InsertModeCommand = new RelayCommand(InsertMode);
			DeleteModeCommand = new RelayCommand(DeleteMode);
			EditModeCommand = new RelayCommand(EditMode);
			_pageModel = new PageModel();
		}

		private void InsertMode(object parameter)
		{

		}
		private void DeleteMode(object parameter)
		{

		}
		private void EditMode(object parameter)
		{

		}
	}
}
