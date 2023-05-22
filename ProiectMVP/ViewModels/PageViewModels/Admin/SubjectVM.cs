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

		public ICommand EditSubjectModeCommand { get; }
		public ICommand DeleteSubjectModeCommand { get; }
		public ICommand InsertSubjectModeCommand { get; }


		public readonly PageModel _pageModel;

		public SubjectVM()
		{
			_pageModel = new PageModel();
			EditSubjectModeCommand = new RelayCommand(EditSubjectMode);
			DeleteSubjectModeCommand = new RelayCommand(DeleteSubjectMode);
			InsertSubjectModeCommand = new RelayCommand(InsertSubjectMode);
		}

		public void EditSubjectMode(object parameter)
		{

		}
		public void DeleteSubjectMode(object parameter)
		{

		}
		public void InsertSubjectMode(object parameter)
		{

		}
	}
}
