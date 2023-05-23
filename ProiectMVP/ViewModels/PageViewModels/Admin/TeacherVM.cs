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
	
		public ICommand EditModeCommand { get; }
		public ICommand DeleteModeCommand { get; }
		public ICommand InsertModeCommand { get; }
		public TeacherVM()
		{
		
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
