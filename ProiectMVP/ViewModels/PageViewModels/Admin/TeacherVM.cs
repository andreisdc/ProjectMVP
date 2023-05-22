using ProiectMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class TeacherVM
	{
		public readonly PageModel _pageModel;
		public ICommand EditTeacherModeCommand { get; }
		public ICommand DeleteTeacherModeCommand { get; }
		public ICommand InsertTeacherModeCommand { get; }
		public TeacherVM()
		{
			_pageModel = new PageModel();
			EditTeacherModeCommand = new RelayCommand(EditTeacherMode);
			DeleteTeacherModeCommand = new RelayCommand(DeleteTeacherMode);
			InsertTeacherModeCommand = new RelayCommand(InsertTeacherMode);
		}
		public void EditTeacherMode(object parameter)
		{

		}
		public void DeleteTeacherMode(object parameter)
		{

		}
		public void InsertTeacherMode(object parameter)
		{

		}
	}
}
