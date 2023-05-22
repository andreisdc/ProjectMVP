using ProiectMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class StudentVM
	{
		public ICommand EditStudentModeCommand { get; }
		public ICommand DeleteStudentModeCommand { get; }
		public ICommand InsertStudentModeCommand { get; }

		public readonly PageModel _pageModel;

		public StudentVM()
		{
			EditStudentModeCommand = new RelayCommand(EditStudentMode);
			DeleteStudentModeCommand = new RelayCommand(DeleteStudentMode);
			InsertStudentModeCommand = new RelayCommand(InsertStudentMode);
			_pageModel = new PageModel();
		}

		public void EditStudentMode(object parameter)
		{

		}
		public void DeleteStudentMode(object parameter)
		{

		}
		public void InsertStudentMode(object parameter)
		{

		}
	}
}
