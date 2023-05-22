using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMVP.Models;
using System.Windows.Input;


namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class NavigationVM : BaseViewModel
	{
		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value; OnPropertyChanged(); }
		}

		public ICommand HomeCommand { get; set; }
		public ICommand StudentCommand { get; set; }
		public ICommand TeacherCommand { get; set; }
		public ICommand SubjectCommand { get; set; }
		public ICommand SettingsCommand { get; set; }
		public ICommand ClassCommand { get; set; }


		private void Home(object parameter) => CurrentView = new HomeVM();
		private void Student(object parameter) => CurrentView = new StudentVM();
		private void Teacher(object parameter) => CurrentView = new TeacherVM();
		private void Subject(object parameter) => CurrentView = new SubjectVM();
		private void Settings(object parameter) => CurrentView = new SettingsVM();
		private void Class(object parameter) => CurrentView = new ClassVM();


		public NavigationVM()
		{
			HomeCommand = new RelayCommand(Home);

			StudentCommand = new RelayCommand(Student);

			TeacherCommand = new RelayCommand(Teacher);

			SubjectCommand = new RelayCommand(Subject);

			SettingsCommand = new RelayCommand(Settings);

			ClassCommand = new RelayCommand(Class);

			CurrentView = new HomeVM();
		}

	}
}
